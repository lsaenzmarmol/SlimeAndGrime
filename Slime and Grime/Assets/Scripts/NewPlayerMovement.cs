using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
     private float horizontalInput;

    public Transform cam;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float turnSmoothTime = 0.1f;
    public float  turnSmoothVelocity; 
    Vector3 velocity;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, forwardInput).normalized;

        transform.Translate(Vector3.forward* Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right* Time.deltaTime * speed * horizontalInput);

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
    }
}
