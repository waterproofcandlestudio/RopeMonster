using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour, ICollisionable
{
    [SerializeField]
    private SoundsFX soundName = SoundsFX.SFX_Lose;

    private Endings typeOfEnding;

    private void Start()
    {
        typeOfEnding = Endings.BadEnding;
    }

    public void OnCollision()
    {
        Debug.Log("Level finished");

        AudioManager.instance.PlayClip(soundName);

        GameManager.instance.FinishLevel(typeOfEnding);
    }
}