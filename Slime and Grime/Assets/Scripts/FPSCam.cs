using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player;

    float rotationUpDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X")* sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y")* sensitivity* Time.deltaTime;

        rotationUpDown -= y;
        rotationUpDown = Mathf.Clamp(rotationUpDown, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationUpDown, 0f, 0f);

        player.Rotate(Vector3.up * x);
    }
}
