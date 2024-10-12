using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Attributes")]
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private float speedToMaxSpeed;
    private float accelerationRate;
    private float moveSpeed;
    private float stopX;
    private float stopY;
    private float stopSpeedX;
    private float stopSpeedY;

    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;

    [SerializeField] private float frictionAmount;
    private float frictionX;
    private float frictionY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pit"))
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveUp();
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }

            if (Input.GetKey(KeyCode.S))
            {
                MoveDown();
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
        }
        else
        {
            Stop();
        }

        Friction();
    }


    private void MoveUp()
    {
        speedToMaxSpeed = maxSpeed - rb.velocity.y;
        if (rb.velocity.y >= 0)
        {
            accelerationRate = acceleration;
        }
        else
        {
            accelerationRate = decceleration;
        }
        moveSpeed = speedToMaxSpeed * accelerationRate;

        rb.AddForce(moveSpeed * Vector2.up);
    }

    private void MoveLeft()
    {
        speedToMaxSpeed = -maxSpeed - rb.velocity.x;
        if (rb.velocity.x <= 0)
        {
            accelerationRate = acceleration;
        }
        else
        {
            accelerationRate = decceleration;
        }
        moveSpeed = -speedToMaxSpeed * accelerationRate;

        rb.AddForce(moveSpeed * Vector2.left);
    }

    private void MoveDown()
    {
        speedToMaxSpeed = -maxSpeed - rb.velocity.y;
        if (rb.velocity.y <= 0)
        {
            accelerationRate = acceleration;
        }
        else
        {
            accelerationRate = decceleration;
        }
        moveSpeed = -speedToMaxSpeed * accelerationRate;

        rb.AddForce(moveSpeed * Vector2.down);
    }

    private void MoveRight()
    {
        speedToMaxSpeed = maxSpeed - rb.velocity.x;
        if (rb.velocity.x >= 0)
        {
            accelerationRate = acceleration;
        }
        else
        {
            accelerationRate = decceleration;
        }
        moveSpeed = speedToMaxSpeed * accelerationRate;

        rb.AddForce(moveSpeed * Vector2.right);
    }

    private void Stop()
    {
        // A force is applied to smoothly stop the player when there are no movement inputs
        stopX = 0 - rb.velocity.x;
        stopY = 0 - rb.velocity.y;
        accelerationRate = decceleration;
        stopSpeedX = stopX * accelerationRate;
        stopSpeedY = stopY * accelerationRate;

        rb.AddForce(stopSpeedX * Vector2.right);
        rb.AddForce(stopSpeedY * Vector2.up);
    }

    private void Friction()
    {
        frictionX = Mathf.Min(Mathf.Abs(rb.velocity.x), frictionAmount);
        frictionX *= Mathf.Sign(rb.velocity.x);
        rb.AddForce(Vector2.right * -frictionX, ForceMode2D.Impulse);

        frictionY = Mathf.Min(Mathf.Abs(rb.velocity.y), frictionAmount);
        frictionY *= Mathf.Sign(rb.velocity.y);
        rb.AddForce(Vector2.up * -frictionY, ForceMode2D.Impulse);
    }
}
