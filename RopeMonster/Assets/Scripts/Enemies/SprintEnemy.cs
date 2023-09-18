using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintEnemy : SimpleEnemy
{
    [SerializeField]
    private float sprintSpeed;

    [SerializeField]
    private float rayDistance = 10f;

    private float startSpeed;

    private void Start()
    {
        startSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        ThrowRaycast();
    }

    private void ThrowRaycast()
    {
        Vector3 origin = new Vector3(transform.position.x - rayDistance, transform.position.y, transform.position.z);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, transform.right * rayDistance * 2);

        if (hits[0].collider != null)
        {
            foreach (RaycastHit2D r in hits)
            {
                if (r.collider.CompareTag("Player"))
                {
                    baseSpeed = sprintSpeed;

                    Debug.Log("Player hit");

                    break;
                }

                baseSpeed = startSpeed;
            }
        }
        else
        {
            baseSpeed = startSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 origin = new Vector3(transform.position.x - rayDistance, transform.position.y, transform.position.z);

        Gizmos.DrawRay(origin, transform.right * rayDistance * 2);
    }
}