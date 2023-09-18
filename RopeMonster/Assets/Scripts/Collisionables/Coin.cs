using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour, ICollisionable
{
    public UnityEvent onCoinCollect;

    public void OnCollision()
    {
        onCoinCollect.Invoke();

        AudioManager.instance.PlayClip(SoundsFX.SFX_Coin);

        Destroy(gameObject);
    }
}