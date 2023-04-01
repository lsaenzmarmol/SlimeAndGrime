using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumpScript : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public int defaultJumpAllowed = 1;
    int jumpAllowed;

    Rigidbody rig;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        jumpAllowed = defaultJumpAllowed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            if(isGrounded)
            {
                Jump();
                isGrounded=false;
            }
        }

        else if(!isGrounded && jumpAllowed > 0)
        {
            Jump();
            jumpAllowed--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
            jumpAllowed = defaultJumpAllowed;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        rig.AddForce(transform.up * jumpSpeed, ForceMode.VelocityChange);
    }
}
