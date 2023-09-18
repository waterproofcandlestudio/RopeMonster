using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public abstract void Move();

    [SerializeField]
    protected float baseSpeed = 5f;

    public virtual void Update()
    {
        Move();
    }
}