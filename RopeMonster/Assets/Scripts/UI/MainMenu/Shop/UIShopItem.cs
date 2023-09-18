using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField]
    private SO_Skin skin;

    [SerializeField]
    private Image body;

    [SerializeField]
    private Image leftArm;

    [SerializeField]
    private Image rightArm;

    [SerializeField]
    private TextMeshProUGUI price;

    private Button button;

    private void OnEnable()
    {
        if (button == null)
            button = GetComponent<Button>();

        DisplayItem();
    }

    public void DisplayItem()
    {
        //Set the skin to the UI
        if (skin != null)
        {
            body.sprite = skin.Body;
            leftArm.sprite = skin.Arm;
            rightArm.sprite = skin.Arm;
            price.text = skin.price.ToString();

            if (button != null)
                button.interactable = true;
        }

        //Dissable the button if we have already bought it
        if (skin.unlocked)
            UnDisplayItem();
    }

    private void UnDisplayItem()
    {
        if (button == null)
            return;

        button.interactable = false;
    }

    private void OnValidate()
    {
        DisplayItem();
    }

    #region GET AND SET

    public SO_Skin GetSkin() => skin;

    public void SetSkin(SO_Skin _skin)
    {
        skin = _skin;
    }

    #endregion GET AND SET
}