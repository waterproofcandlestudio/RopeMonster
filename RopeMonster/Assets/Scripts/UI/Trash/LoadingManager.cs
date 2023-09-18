using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;

    [SerializeField] GameObject loadingPanel;
    [SerializeField] float minLoadTime;

    [SerializeField] GameObject LoadingWheel;
    [SerializeField] float wheelSpeed;

    [SerializeField] Image fadeImage;
    [SerializeField] float fadeTime;

    string targetScene;
    bool isLoading;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        loadingPanel.SetActive(false);
        fadeImage.gameObject.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }
    IEnumerator LoadSceneRoutine()
    {
        isLoading = true;

        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
            yield return null;

        loadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        while (!Fade(0))
            yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (elapsedLoadTime < minLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (!Fade(1))
            yield return null;

        loadingPanel.SetActive(false);

        while (!Fade(0))
            yield return null;

        isLoading = false;
    }

    bool Fade(float target)
    {
        fadeImage.CrossFadeAlpha(target, fadeTime, true);

        if (Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            fadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }
    /// <summary>
    ///     Loading icon animation
    /// </summary>
    IEnumerator SpinWheelRoutine()
    {
        while (isLoading)   
        {
            LoadingWheel.transform.Rotate(0, 0, -wheelSpeed);
            yield return null;
        }
    }
}
