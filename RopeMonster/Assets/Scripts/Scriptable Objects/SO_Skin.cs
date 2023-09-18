using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skin/New Skin")]
public class SO_Skin : ScriptableObject
{
    public string skinName = "Default Skin";

    public int price = 1;

    public bool unlocked = false;

    public Sprite Body;
    public Sprite Arm;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}