using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxComponent : MonoBehaviour
{
    public LayerPriority parallaxLayer;

    private float startPos;

    private float dist;

    private float parallaxMultipliyer;

    private ParallaxController parallaxController;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        parallaxController = GetComponentInParent<ParallaxController>();

        startPos = transform.position.y;

        parallaxMultipliyer = parallaxController.GetParallaxMultipliyer(parallaxLayer);
    }

    private void Update()
    {
        dist += parallaxController.panningSpeed * parallaxMultipliyer * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, (startPos - dist), transform.position.z);
    }

    public float GetResetPosition() => parallaxController.GetResetPosition(parallaxLayer, spriteRenderer);

    public void ResetPos(float resetPos)
    {
        startPos = resetPos;
        dist = 0;
    }
}