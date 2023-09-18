using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColliderGenerator : MonoBehaviour
{
    private Camera viewportCamera;

    private void Awake()
    {
        viewportCamera = Camera.main;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GenerateCollidersAcrossScreen();
    }

    private void GenerateCollidersAcrossScreen()
    {
        Vector2 lDCorner = viewportCamera.ViewportToWorldPoint(new Vector3(0, 0f, viewportCamera.nearClipPlane));
        Vector2 rUCorner = viewportCamera.ViewportToWorldPoint(new Vector3(1f, 1f, viewportCamera.nearClipPlane));
        Vector2[] colliderpoints;

        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);

        upperEdge.points = colliderpoints;
        upperEdge.transform.parent = this.transform;
        upperEdge.gameObject.tag = "BorderCollider";

        EdgeCollider2D lowerEdge = new GameObject("lowerEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = lowerEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);

        lowerEdge.points = colliderpoints;
        lowerEdge.transform.parent = this.transform;
        lowerEdge.gameObject.tag = "BorderCollider";

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
        leftEdge.points = colliderpoints;
        leftEdge.transform.parent = this.transform;
        leftEdge.gameObject.tag = "BorderCollider";

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);

        rightEdge.points = colliderpoints;
        rightEdge.transform.parent = this.transform;
        rightEdge.gameObject.tag = "BorderCollider";
    }
}