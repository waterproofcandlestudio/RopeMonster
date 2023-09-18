using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<SO_Level> allLevels;

    [SerializeField]
    private List<Button> UILevels;

    private void Start()
    {
        CheckLevels();
    }

    private void CheckLevels()
    {
        for (int i = 0; i < allLevels.Count; i++)
        {
            //If the level is completed, then we unlock it

            if (allLevels[i].isCompleted || allLevels[i].isUnlocked)
            {
                allLevels[i].isUnlocked = true;
            }

            //If the actual level is not completed, then we check if the previous is completed and unlocked

            if (!allLevels[i].isCompleted)
            {
                if (i - 1 < 0)
                {
                    continue;
                }

                if (allLevels[i - 1].isCompleted && allLevels[i - 1].isUnlocked)
                {
                    allLevels[i].isUnlocked = true;
                }
            }

            //Manage button interactibity

            if (allLevels[i].isUnlocked)
                UILevels[i].interactable = true;
            else
                UILevels[i].interactable = false;
        }
    }
}