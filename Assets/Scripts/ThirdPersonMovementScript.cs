using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript : MonoBehaviour
{
    // Essentials
    public CharacterController controller;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // Movement
    Vector2 movement;
    public float speed;
    public float walk;
    float trueSpeed;

    // Jumping
    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;

    void Start()
    {
        // Default speed
        trueSpeed = speed;

        // Hide the cursor when the game starts
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get input for movement in the horizontal and vertical directions.
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, 7);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // slower walk speed
        {
            trueSpeed = walk;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // default walk speed
        {
            trueSpeed = speed;
        }

        // Create a normalized vector for movement direction.
         movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

      // Check if there is significant movement input(magnitude greater than or equal to 0.1).
        if (movement.magnitude >= 0.1f)
        {
            // Calculate the target angle for rotation based on input direction and camera's orientation.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Calculate the smoothed angle for rotation using SmoothDampAngle function.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Set the rotation of the object in the Y-axis to the smoothed angle.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate the movement direction based on the target angle.
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Move the character controller in the calculated direction at the specified speed.
            controller.Move(moveDir.normalized * trueSpeed * Time.deltaTime);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)          
        {
            
            velocity.y = Mathf.Sqrt((jumpHeight * -2f * gravity) * 10); // Corrected jump calculation
        }
        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
   
    }

 
}



