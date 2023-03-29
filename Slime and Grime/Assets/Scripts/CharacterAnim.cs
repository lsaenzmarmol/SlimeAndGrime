using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKey("a"))
        {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKey("d"))
        {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKey("s"))
        {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("isWalking", false);
        }


        if (Input.GetKey("space"))
        {
            anim.SetBool("isDoubleJumping", true);
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetBool("isJumping", true);
        }


        if (Input.GetKeyUp("space"))
        {
            anim.SetBool("isDoubleJump", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isLanding", true);
        }



    }
}
