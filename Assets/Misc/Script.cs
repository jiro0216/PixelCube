using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed ;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Apply the movement to the player using Rigidbody
        rb.velocity = movement * speed;
    }
}