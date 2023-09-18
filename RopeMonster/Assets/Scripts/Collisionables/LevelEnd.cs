using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour, ICollisionable
{
    [SerializeField]
    private Endings typeOfEnding;

    public void OnCollision()
    {
        Debug.Log("Level finished");

        GameManager.instance.FinishLevel(typeOfEnding);
    }
}