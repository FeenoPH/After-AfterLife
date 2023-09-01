using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float maxSpeed = 10f;
    public Rigidbody2D rb;
    public float acceleration = 20f;
    public float deceleration = 50f;
    private float currentSpeed = 0f;
    private bool Touching_ground = false;
    public float jump;

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

        if (Touching_ground == true && Input.GetButtonDown("Jump") == true)
        {
            rb.AddForce(Vector2.up * jump);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            Touching_ground = true;
        }
    }
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            Touching_ground = false;
        }
    }


}
