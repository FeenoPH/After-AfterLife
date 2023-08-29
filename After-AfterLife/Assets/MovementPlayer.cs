using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float maxUpward = 10f;
    public Rigidbody2D rb;
    public float acceleration = 20f;
    public float upward_acceleration = 20f;
    public float downward_acceleration = 20f;
    public float deceleration = 50f;
    private float jumpSpeed = 0f;
    private float currentSpeed = 0f;
    private bool IsPeak = false;

    void Update()
    {
        // Calculate desired speed based on user input
        float targetSpeed = Input.GetAxis("Horizontal") * maxSpeed;

        // Accelerate or decelerate to reach the target speed
        if ((targetSpeed > currentSpeed && Input.GetAxis("Horizontal") > 0) || (targetSpeed < currentSpeed && Input.GetAxis("Horizontal") < 0))
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.deltaTime);

        // Apply the calculated speed to the rigidbody's velocity
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if (Input.GetButton("Jump") == true && IsPeak == false)
        {
            jumpSpeed += upward_acceleration * Time.deltaTime;
            rb.velocity = new Vector2(currentSpeed, jumpSpeed);
            if (jumpSpeed >= maxUpward)
            {
                IsPeak = true;
                jumpSpeed -= downward_acceleration * Time.deltaTime; 
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            IsPeak = false;
            jumpSpeed = 0f;
        }
    }
}
