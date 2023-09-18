using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private SO_CoinCounter playerCoins;

    [SerializeField]
    private GameObject purchaseWindow;

    [SerializeField]
    private GameObject shopWindow;

    private SO_Skin actualSkin;
    private UIShopItem actualItem;

    public UnityEvent<int> onSkinPurchase;

    public void CheckPurchase(UIShopItem skinToPurchase)
    {
        //Check for money
        if (playerCoins.coins >= skinToPurchase.GetSkin().price)
        {
            //Purchase window
            UIShopItem displaySkin = purchaseWindow.GetComponent<UIShopItem>();

            actualItem = skinToPurchase;

            displaySkin.SetSkin(skinToPurchase.GetSkin());

            actualSkin = skinToPurchase.GetSkin();

            purchaseWindow.SetActive(true);
        }
        else
        {
            //Go to shop window
            shopWindow.SetActive(true);
        }
    }

    public void SkinPurchased()
    {
        onSkinPurchase.Invoke(actualSkin.price);

        //Unlock the purchased skin
        actualSkin.unlocked = true;

        actualItem.DisplayItem();
    }
}