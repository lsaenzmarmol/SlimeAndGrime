using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashPickUp : MonoBehaviour
{
    public float speedBoostAmount = 2f;
    public AudioClip pickupSound;
    private TextMeshProUGUI pickupText;
    public float rotationSpeed = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NewPlayerMovement playerMovement = other.GetComponent<NewPlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.AddSpeedBoost(speedBoostAmount);
            }

            pickupText = GetComponentInChildren<TextMeshProUGUI>();
            if (pickupText != null)
            {
                pickupText.text = "Speed Boost Picked Up!";
            }
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Rotate the pickup object around its y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}