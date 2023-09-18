using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWardrobeItem : MonoBehaviour
{
    [SerializeField]
    private SO_Skin skin;

    [SerializeField]
    private Image body;

    [SerializeField]
    private Image leftArm;

    [SerializeField]
    private Image rightArm;

    private void OnEnable()
    {
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
            gameObject.SetActive(true);
        }

        //Dissable the GO if we dont have the skin unlocked yet
        if (!skin.unlocked)
            UnDisplayItem();
    }

    private void UnDisplayItem()
    {
        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        DisplayItem();
    }

    public SO_Skin GetSkin() => skin;
}