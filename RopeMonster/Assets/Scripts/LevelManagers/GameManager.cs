using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField]
    private SO_Level level;

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private GameObject endLevelPanel;

    public delegate void LevelEndEvent();

    public static event LevelEndEvent levelEndDelegate;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void FinishLevel(Endings typeOfEndign)
    {
        if (typeOfEndign == Endings.GoodEnding)
        {
            endLevelPanel.SetActive(true);
            level.isCompleted = true;
        }
        else if (typeOfEndign == Endings.BadEnding)
        {
            losePanel.SetActive(true);
        }

        //Invoca todos los métodos suscritos a este método
        levelEndDelegate.Invoke();
    }
}

public enum Endings
{
    GoodEnding,
    BadEnding,
    None
}