using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhaseAbility : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private Rigidbody myRb;
    private bool isCooldown;
    private bool isPhasing;
    public TextMeshProUGUI cooldownText;
    float startTime;

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
                startTime = Time.time;
                StartCoroutine(StartCooldown());
            }
        }
        if (isPhasing)
        {
            StartCoroutine(StopPhasing());
        }

        if (isCooldown)
        {
            float remainingTime = Mathf.CeilToInt(10 - (Time.time - startTime));
            cooldownText.text = "Cooldown: " + remainingTime.ToString();
        }
        else
        {
            cooldownText.text = "";
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
        cooldownText.text = "";
    }

    IEnumerator StopPhasing()
    {
        yield return new WaitForSeconds(2);
        isPhasing = false;
        EnableCollider();
    }
}