using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    public float teleportDistance = 10f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TeleportForward();

            AudioManager.Instance.PlaySFX("Slime Teleport");
        }
    }

    private void TeleportForward()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 newPosition = transform.position + forward * teleportDistance;
        transform.position = newPosition;
    }
}
