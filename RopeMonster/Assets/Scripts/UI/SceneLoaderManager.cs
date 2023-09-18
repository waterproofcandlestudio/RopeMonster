using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int indexOfLevel)
    {
        string levelToLoad = "Lvl_" + indexOfLevel.ToString();
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadNextLevel()
    {
        string actualLevel = SceneManager.GetActiveScene().name;
        string temp = string.Empty;
        int val = 0;

        for (int i = 0; i < actualLevel.Length; i++)
        {
            if (Char.IsDigit(actualLevel[i]))
                temp += actualLevel[i];
        }

        if (temp.Length > 0)
            val = int.Parse(temp);

        val++;

        temp = "Lvl_" + val.ToString();

        if (SceneManager.GetSceneByName(temp) != null)
        {
            SceneManager.LoadScene(temp);
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
}