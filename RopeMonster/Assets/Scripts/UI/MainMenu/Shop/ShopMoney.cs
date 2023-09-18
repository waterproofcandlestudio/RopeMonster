using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMoney : MonoBehaviour
{
    [SerializeField]
    private SO_CoinCounter playerCoins;

    [SerializeField]
    private TextMeshProUGUI coins;

    [SerializeField]
    private TextMeshProUGUI premiumCoins;

    private void Awake()
    {
        coins.text = playerCoins.coins.ToString();
    }

    private void Update()
    {
        coins.text = playerCoins.coins.ToString();
    }

    public void UpdateMoney(int skinPrice)
    {
        //Animación para reducir el dinero del jugador
        playerCoins.coins -= skinPrice;

        coins.text = playerCoins.coins.ToString();
    }
}