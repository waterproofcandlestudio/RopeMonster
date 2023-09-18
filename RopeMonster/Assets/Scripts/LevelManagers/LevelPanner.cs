using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanner : MonoBehaviour
{
    [SerializeField]
    private float panningSpeed = 1f;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(0, transform.position.y - panningSpeed * Time.deltaTime, 0);
    }

    public void StopLevel()
    {
        panningSpeed = 0f;
    }

    private void OnEnable()
    {
        GameManager.levelEndDelegate += StopLevel;
    }

    private void OnDisable()
    {
        GameManager.levelEndDelegate += StopLevel;
    }
}