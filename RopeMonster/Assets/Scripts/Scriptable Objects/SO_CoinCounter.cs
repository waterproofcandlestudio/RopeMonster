using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("CoinHolder / New Coin Holder"))]
public class SO_CoinCounter : ScriptableObject
{
    public int coins;

    public void AddCoin(int newCoins = 1)
    {
        coins += newCoins;
    }

    public void AddCoin()
    {
        coins++;
    }

    public int ReturnTotalCoins() => coins;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}