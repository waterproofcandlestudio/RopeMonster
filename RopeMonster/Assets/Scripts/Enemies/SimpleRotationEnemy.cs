using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotationEnemy : EnemyAI
{
    [SerializeField]
    private float rotationAngle = 45f;

    public override void Move()
    {
        Vector3 rotation = new Vector3(0, 0, rotationAngle);

        transform.Rotate(rotation * baseSpeed * Time.deltaTime);
    }
}
