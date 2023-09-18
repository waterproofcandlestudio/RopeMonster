using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingEnemy : EnemyAI
{
    private CircleCollider2D collider;

    [SerializeField]
    private float timeBtwAttacks = 2.5f;

    [SerializeField]
    private float retractWaitTime = 0.2f;

    [SerializeField]
    private float maxAttackRadius = 2f;

    private float minAttackRadius;
    private float t;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();

        minAttackRadius = collider.radius;
    }

    public override void Move()
    {
        //Un timer para contar el tiempo entre ataques
        t += Time.deltaTime;

        //Si el contador llega a maxTime entonces hacemos el ataque
        if (t >= timeBtwAttacks)
        {
            StopAllCoroutines();

            StartCoroutine(AttackRoutine());

            t = 0;
        }
    }

    private IEnumerator AttackRoutine()
    {
        //collider.radius = maxAttackRadius;

        while (collider.radius < maxAttackRadius)
        {
            collider.radius += baseSpeed * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(retractWaitTime);

        while (collider.radius > minAttackRadius)
        {
            collider.radius -= baseSpeed * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }
}