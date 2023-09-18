using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    [SerializeField]
    private SO_PlayerSkin playerSkin;

    [SerializeField]
    private SpriteRenderer body;

    [SerializeField]
    private SpriteRenderer leftArm;

    [SerializeField]
    private SpriteRenderer rightArm;

    private void Awake()
    {
        if (playerSkin != null)
        {
            body.sprite = playerSkin.actualSkin.Body;
            leftArm.sprite = playerSkin.actualSkin.Arm;
            rightArm.sprite = playerSkin.actualSkin.Arm;
        }
    }
}