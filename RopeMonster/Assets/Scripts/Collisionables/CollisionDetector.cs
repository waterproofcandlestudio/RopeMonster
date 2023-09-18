using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private bool debug = true;

    [SerializeField]
    private LayerMask collisionableLayers;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (debug)
            Debug.Log(this.gameObject.name + " has detected a collision with: " + collision.collider.name);

        if (collision == null)
            return;

        //Detect the layer we want to collide with

        if ((collisionableLayers.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            ICollisionable collisionable = collision.gameObject.GetComponent<ICollisionable>();

            if (collisionable != null)
                collisionable.OnCollision();
        }
    }
}