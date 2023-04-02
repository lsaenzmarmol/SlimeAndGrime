using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TeleportAbility : MonoBehaviour
{
    public float teleportDistance = 10f;
    public int maxUses = 3; 
    public float cooldownTime = 5f; 
    private int usesLeft; 
    private float lastUsedTime; 
    public TextMeshProUGUI usesLeftText;

    private void Start()
    {
        usesLeft = maxUses;
        lastUsedTime = -cooldownTime;
        UpdateUsesLeftText();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")&& Time.time - lastUsedTime > cooldownTime && usesLeft > 0)
        {
            TeleportForward();
            AudioManager.Instance.PlaySFX("Slime Teleport");
            usesLeft--;
            lastUsedTime = Time.time;
            UpdateUsesLeftText();
        }
    }

    private void TeleportForward()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 newPosition = transform.position + forward * teleportDistance;
        transform.position = newPosition;
    }
    public void ResetUses()
    {
        usesLeft = maxUses;
        lastUsedTime = -cooldownTime;
        UpdateUsesLeftText();
    }
    private void UpdateUsesLeftText()
    {
        if (usesLeftText != null)
        {
            usesLeftText.text = "Uses left: " + usesLeft.ToString();
        }
    }
}
