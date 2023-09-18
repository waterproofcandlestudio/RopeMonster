using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : EnemyAI
{
    [SerializeField]
    private float startAngle = 0f;

    [SerializeField]
    private float targetAngle = 180f;

    [SerializeField]
    private float attackWaitTime = 3.5f;

    private Quaternion initialRotation;
    private Quaternion finalRotation;
    private Quaternion targetRotation;
    private float rotationProgress;
    private float t;

    private void Start()
    {
        initialRotation = transform.rotation;
        finalRotation = Quaternion.Euler(0f, 0f, targetAngle);
    }

    public override void Move()
    {
        t += Time.deltaTime;

        if (t >= attackWaitTime)
        {
            StartCoroutine(RotateCollider(finalRotation));
            t = 0;
        }
    }

    private IEnumerator RotateCollider(Quaternion targetRotation)
    {
        float elapsedTime = 0;

        while (transform.rotation != targetRotation)
        {
            elapsedTime += Time.deltaTime;
            rotationProgress = Mathf.Clamp01(elapsedTime / baseSpeed);

            Quaternion newRotation = Quaternion.Lerp(initialRotation, targetRotation, rotationProgress);
            transform.rotation = newRotation;

            yield return null;
        }

        targetRotation = initialRotation;

        elapsedTime = 0;

        while (transform.rotation != targetRotation)
        {
            elapsedTime += Time.deltaTime;
            rotationProgress = Mathf.Clamp01(elapsedTime / baseSpeed);

            Quaternion newRotation = Quaternion.Lerp(finalRotation, targetRotation, rotationProgress);
            transform.rotation = newRotation;

            yield return null;
        }

        // Ensure the collider reaches the target rotation exactly
        transform.rotation = targetRotation;
    }
}