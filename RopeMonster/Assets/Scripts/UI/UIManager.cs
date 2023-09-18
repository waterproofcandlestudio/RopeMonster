using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;
    [SerializeField] private GameObject pauseButtonsCanvas = null;
    [SerializeField] private GameObject optionsCanvas = null;
    [SerializeField] private GameObject endCanvas = null;

    private void Awake() => GetReferences();

    private void Start() => InitializeVariables();

    //void Update()   => Time.timeScale = isPaused ? 0 : 1;

    public void TestChangeScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void ActivateIngameMenu()
    {
        //UI_AudioManager.PlayButtonSound(uISounds.button_Sound);

        //if (!stats.IsDead())
        //{
        if (!isPaused)
        {
            SetActivePause(true);
            Time.timeScale = 0f;
        }
        else if (isPaused)
        {
            SetActivePause(false);
            Time.timeScale = 1f;
        }
        //}
    }

    public void ActivateGame()
    {
        SetActivePause(false);
        Time.timeScale = 1f;
    }

    private void SmoothlyChangeTime(float initialTime, float finalTime)
    {
        Time.timeScale = Mathf.Lerp(initialTime, finalTime, Time.smoothDeltaTime);
    }

    public void SetActiveHud(bool state)    // Playing game
    {
        hudCanvas.SetActive(state);
        endCanvas.SetActive(!state);
        optionsCanvas.SetActive(!state);

        //if (!stats.IsDead())        pauseCanvas.SetActive(!state);
    }

    public void SetActivePause(bool state)  // Pausing ingame
    {
        hudCanvas.SetActive(!state);
        pauseCanvas.SetActive(state);
        pauseButtonsCanvas.SetActive(state);
        optionsCanvas.SetActive(!state);

        isPaused = state;
    }

    public void SetActiveOptionsMenu(bool state)  // Pausing ingame
    {
        pauseButtonsCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public bool GameIsPaused() => isPaused;

    public void Restart()
    {
        //SetActivePause(false);
        SceneManager.LoadScene(1);
    }

    public void MainMenu() => SceneManager.LoadScene(0);

    public void Quit() => Application.Quit();

    private void GetReferences()
    {
        //stats = GetComponent<PlayerStats>();
        //cameraController = GetComponent<CameraController>();
    }

    private void InitializeVariables()
    {
        SetActiveHud(true);
    }
}