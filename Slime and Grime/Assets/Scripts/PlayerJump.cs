using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public int defaultJumpAllowed = 2; 
    public float doubleJumpSpeed = 7f;
    int jumpAllowed;
    Rigidbody rig;
    bool isGrounded;
    float lastJumpTime;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        jumpAllowed = defaultJumpAllowed;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded || (jumpAllowed > 0 && Time.time > lastJumpTime + 0.1f && rig.velocity.y < 0.1f)) 
            {
                Jump();
                isGrounded=false;
                jumpAllowed--;
                lastJumpTime = Time.time;
                AudioManager.Instance.PlaySFX("Slime Jump");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
                jumpAllowed = defaultJumpAllowed;
                rig.velocity = Vector3.zero;
            }
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rig.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            AudioManager.Instance.PlaySFX("Slime Jump");
        }
        else if (jumpAllowed > 0)
        {
            rig.velocity = new Vector3(rig.velocity.x, 0f, rig.velocity.z);
            rig.AddForce(transform.up * doubleJumpSpeed, ForceMode.Impulse);
            AudioManager.Instance.PlaySFX("Slime Jump");
            jumpAllowed--;
        }
    }
}
