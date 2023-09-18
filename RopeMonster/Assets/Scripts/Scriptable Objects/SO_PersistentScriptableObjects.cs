using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Persistent Data"))]
public class SO_PersistentScriptableObjects : ScriptableObject
{
    public SO_CoinCounter wallet;

    public SO_Level[] levels;

    public List<SO_Skin> skins;

    public SO_PlayerSkin playerSkin;

    public void LoadData(GameData gameData)
    {
        if (gameData == null)
            return;

        wallet.coins = gameData.coins;

        for (int i = 0; i < gameData.levelsCompleted.Length; i++)
        {
            levels[i].isCompleted = gameData.levelsCompleted[i];
            levels[i].isUnlocked = gameData.levelsUnlocked[i];
        }

        for (int i = 0; i < gameData.skins.Length; i++)
        {
            skins[i].unlocked = gameData.skins[i];
        }

        playerSkin.actualSkin = skins[gameData.actualSkinIndex];
    }
}