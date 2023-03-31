using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float rotationDamping = 10.0f;
    public float heightDamping = 5.0f;
    public float rotationSpeed = 5.0f;

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            float currentRotationAngle = transform.eulerAngles.y;
            currentRotationAngle += mouseX * rotationSpeed;
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            Vector3 targetPosition = target.position - currentRotation * Vector3.forward * distance;

            float rotationAngle = transform.eulerAngles.x - mouseY * rotationSpeed;
            rotationAngle = Mathf.Clamp(rotationAngle, -30, 60);

            float currentHeight = transform.position.y;
            float wantedHeight = target.position.y + height;

            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            currentRotation = Quaternion.Euler(rotationAngle, currentRotationAngle, 0);
            targetPosition = target.position - currentRotation * Vector3.forward * distance;

            targetPosition.y = currentHeight;

            transform.position = targetPosition;
            transform.LookAt(target);
        }
    }
}