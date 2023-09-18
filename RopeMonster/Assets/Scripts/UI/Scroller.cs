using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    private RawImage image;

    [SerializeField]
    private Vector2 panningSpeed;

    private void Awake()
    {
        image = GetComponent<RawImage>();
    }

    private void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(panningSpeed.x, panningSpeed.y) * Time.deltaTime, image.uvRect.size);
    }
}