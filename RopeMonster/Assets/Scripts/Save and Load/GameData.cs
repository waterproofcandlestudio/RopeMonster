using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins = 0;

    public bool[] levelsUnlocked;
    public bool[] levelsCompleted;

    public bool[] skins;

    public int actualSkinIndex = 0;

    public GameData(SO_PersistentScriptableObjects data)
    {
        coins = data.wallet.coins;

        levelsUnlocked = new bool[data.levels.Length];
        levelsCompleted = new bool[data.levels.Length];

        for (int i = 0; i < data.levels.Length; i++)
        {
            levelsCompleted[i] = data.levels[i].isCompleted;
            levelsUnlocked[i] = data.levels[i].isUnlocked;
        }

        skins = new bool[data.skins.Count];

        for (int i = 0; i < data.skins.Count; i++)
        {
            skins[i] = data.skins[i].unlocked;
        }

        actualSkinIndex = data.skins.IndexOf(data.playerSkin.actualSkin);
    }
}