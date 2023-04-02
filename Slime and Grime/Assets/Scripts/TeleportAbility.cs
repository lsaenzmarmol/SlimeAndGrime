using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    // Update is called once per frame
    public float teleportDistance = 2.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
