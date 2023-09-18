using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Parallax"))
        {
            //Call to reset the position of the parallax component that we collisioned with
            ParallaxComponent parallaxComponent = collision.GetComponent<ParallaxComponent>();

            parallaxComponent.ResetPos(parallaxComponent.GetResetPosition());
        }
    }
}