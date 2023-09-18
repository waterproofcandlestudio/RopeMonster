using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    [SerializeField]
    private string tagToDespawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToDespawn))
        {
            print("Detected collision with: " + collision.name);
            collision.gameObject.SetActive(false);
        }
    }
}