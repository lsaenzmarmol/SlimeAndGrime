using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseAbility : MonoBehaviour
{
    private SphereCollider sphereCollider;
    
    private Rigidbody myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            if (sphereCollider.enabled)
            {
                DisableCollider();
            }
            else
            {
                EnableCollider();
            }
        }
    }

    public void DisableCollider()
    {
        sphereCollider.enabled = false;
        myRb.useGravity = false;
    }

    public void EnableCollider()
    {
        sphereCollider.enabled = true;
        myRb.useGravity = true;
    }
}