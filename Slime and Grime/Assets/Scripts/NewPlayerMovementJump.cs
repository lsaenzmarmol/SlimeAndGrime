using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovementJump : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;

    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float jumpForce = 10f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGrounded;

    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isJumping = false;
    private int jumpCount = 0;
    private int maxJumpCount = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isJumping = true;
                jumpCount = 1;
            }
            else if (jumpCount < maxJumpCount)
            {
                isJumping = true;
                jumpCount++;
            }
        }

        // Get input for movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");

        // Determine movement direction based on camera direction
        Vector3 direction = new Vector3(horizontalInput, 0f, forwardInput).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply movement to rigidbody
            if (!isJumping)
            {
                rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
            }
            else
            {
                rb.velocity = new Vector3(moveDir.x * speed, jumpForce, moveDir.z * speed);
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

        // Reset jump flag
        if (isGrounded)
        {
            isJumping = false;
        }
    }
}

