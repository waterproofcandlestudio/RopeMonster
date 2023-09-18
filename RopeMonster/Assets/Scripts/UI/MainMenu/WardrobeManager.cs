using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeManager : MonoBehaviour
{
    [SerializeField]
    private List<UIWardrobeItem> wardrobeItems = new List<UIWardrobeItem>();

    [SerializeField]
    private SO_PlayerSkin playerSkin;

    [SerializeField]
    private Image body;

    [SerializeField]
    private Image leftArm;

    [SerializeField]
    private Image rightArm;

    private SO_Skin actualSkin;

    public void RefeshWardrobe()
    {
        body.sprite = playerSkin.actualSkin.Body;
        leftArm.sprite = playerSkin.actualSkin.Arm;
        rightArm.sprite = playerSkin.actualSkin.Arm;

        foreach (var item in wardrobeItems)
        {
            item.DisplayItem();
        }
    }

    public void DisplaySkin(UIWardrobeItem skinToDisplay)
    {
        actualSkin = skinToDisplay.GetSkin();

        body.sprite = actualSkin.Body;
        leftArm.sprite = actualSkin.Arm;
        rightArm.sprite = actualSkin.Arm;
    }

    public void EquipSkin()
    {
        playerSkin.actualSkin = actualSkin;
    }
}