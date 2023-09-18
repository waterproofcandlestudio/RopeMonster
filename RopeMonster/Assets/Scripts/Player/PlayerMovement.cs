using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private MovementJoystick joystick;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float maxSpeed = 15f;

    [SerializeField]
    private float smoothTime = 0.1f;

    private Vector2 current;

    private Rigidbody2D rb;

    private bool canMove = true;

    // Start is called before the first frame update
    private void Start()
    {
        joystick = FindObjectOfType<MovementJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
            Move();
        else
            ReduceVelocityToZero();
    }

    private void Move()
    {
        if (joystick.joystickVec.y != 0)
        {
            //rb.AddForce(joystick.joystickVec * speed, ForceMode2D.Force);

            rb.velocity = joystick.joystickVec * speed;

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            ReduceVelocityToZero();
        }
    }

    private void ReduceVelocityToZero()
    {
        rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.zero, ref current, smoothTime);
    }

    private void StopPlayer()
    {
        canMove = false;
    }

    private void OnEnable()
    {
        GameManager.levelEndDelegate += StopPlayer;
    }

    private void OnDisable()
    {
        GameManager.levelEndDelegate += StopPlayer;
    }
}