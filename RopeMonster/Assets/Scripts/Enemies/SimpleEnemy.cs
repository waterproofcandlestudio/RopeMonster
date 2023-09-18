using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleEnemy : EnemyAI
{
    [Space(10)]
    [SerializeField]
    private WayPoints[] wayPoints;

    [Space(10)]
    [Tooltip("If the sprite has to be flipped when it goes from right left or viceversa")]
    [SerializeField]
    private bool hasSpriteFlip = false;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private float stopTimer = 0f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        transform.position = wayPoints[0].waypoint.position;
    }

    public override void Move()
    {
        if (stopTimer > 0f)
        {
            //Control the stop timer

            stopTimer -= Time.deltaTime;

            if (stopTimer <= 0f)
            {
                stopTimer = 0f;

                currentWaypointIndex++;

                if (currentWaypointIndex == wayPoints.Length)
                {
                    movingForward = !movingForward;
                    currentWaypointIndex = movingForward ? 0 : wayPoints.Length - 1;
                }
            }
        }
        else
        {
            //Set new waypoint

            Transform currentWaypoint = wayPoints[currentWaypointIndex].waypoint;

            float distanceToWaypoint = Vector3.Distance(transform.position, currentWaypoint.position);

            if (distanceToWaypoint < 0.1f)
            {
                //Set the stop timer if we have reached the waypoint

                stopTimer = wayPoints[currentWaypointIndex].waitTime;
            }
            else
            {
                //Move the enemy

                Vector3 direction = (currentWaypoint.position - transform.position).normalized;

                transform.position += direction * baseSpeed * Time.deltaTime;

                if (hasSpriteFlip)
                {
                    // Change the sprite direction based on movement

                    if (direction.x > 0f)
                    {
                        // Don't flip (Going Right)

                        spriteRenderer.flipX = false;
                    }
                    else if (direction.x < 0f)
                    {
                        // Flip (Going Left)

                        spriteRenderer.flipX = true;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var item in wayPoints)
        {
            if (item == null)
                continue;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(item.waypoint.position, 0.25f);
        }
    }
}

[System.Serializable]
public class WayPoints
{
    public Transform waypoint;

    [Tooltip("Time that passes between getting to a point, and then reaching the next one")]
    public float waitTime = 0.5f;
}