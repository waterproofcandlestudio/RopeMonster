using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSkinDisplayer : MonoBehaviour
{
    [SerializeField]
    private SO_PlayerSkin playerSkin;

    [SerializeField]
    private Image body;

    [SerializeField]
    private Image leftArm;

    [SerializeField]
    private Image rightArm;

    private void Start()
    {
        DisplayMainSkin();
    }

    private void OnEnable()
    {
        DisplayMainSkin();
    }

    private void DisplayMainSkin()
    {
        body.sprite = playerSkin.actualSkin.Body;
        leftArm.sprite = playerSkin.actualSkin.Arm;
        rightArm.sprite = playerSkin.actualSkin.Arm;
    }
}