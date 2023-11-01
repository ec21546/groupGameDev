using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    private Rigidbody rb;
    public float jumpForce = 10.0f; // Adjust the jump force as needed
    private bool isGrounded = true; // To check if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();

        Vector3 moveVelocity = movement * moveSpeed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump")) // You can set the "Jump" input button in the Input Manager
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
{
    // Check if the player is grounded
    if (collision.gameObject.CompareTag("floor")) // Tag your ground GameObject as "Ground"
    {
        isGrounded = true;
    }
}
}
