using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseAbility : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private Rigidbody myRb;
    private bool isCooldown;
    private bool isPhasing;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        isCooldown = false;
        isPhasing = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && !isCooldown)
        {
            if (sphereCollider.enabled)
            {
                DisableCollider();
                isPhasing = true;
                StartCoroutine(StartCooldown());
            }
        }

        if (isPhasing)
        {
            StartCoroutine(StopPhasing());
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

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(10);
        isCooldown = false;
    }

    IEnumerator StopPhasing()
    {
        yield return new WaitForSeconds(2);
        isPhasing = false;
        EnableCollider();
    }
}