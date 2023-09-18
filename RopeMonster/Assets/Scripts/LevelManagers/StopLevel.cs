using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLevel : MonoBehaviour
{
    private LevelPanner levelPanner;

    private ParallaxController parallaxController;

    private void Awake()
    {
        levelPanner = GetComponentInParent<LevelPanner>();
        parallaxController = FindObjectOfType<ParallaxController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("BorderCollider"))
        {
            parallaxController.StopParallax();
            levelPanner.StopLevel();
        }
    }
}