using UnityEngine;

public class CamerFollow : MonoBehaviour
{   
    public Transform target;
    public float smoothSpeed = 0125f;
    public Vector3 offset;

    void FixedUpdate ()
    {
        Vector3 desirdePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desirdePosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
