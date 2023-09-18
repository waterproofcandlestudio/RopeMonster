using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [SerializeField] Scene[] gameLevels;

    public enum Scene
    {
        MainMenu,
        Lvl_1,
        Lvl_2,
        Lvl_3,
        Lvl_4,
        Lvl_5,
        Lvl_6,
        Lvl_7,
        Lvl_8,
        Lvl_9,
        Lvl_10
    }

    public void LoadLevel_Scene(int index)
    {
        SceneManager.LoadScene(gameLevels[index].ToString());
    }
}
