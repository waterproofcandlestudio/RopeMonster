using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    [SerializeField]
    private SO_PersistentScriptableObjects data;

    private GameData gameData;

    private void Awake()
    {
        gameData = SavingSystem.Load();
        data.LoadData(gameData);
    }

    private void OnEnable()
    {
        gameData = SavingSystem.Load();
        data.LoadData(gameData);
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        gameData = new GameData(data);
        SavingSystem.Save(gameData);
    }
}