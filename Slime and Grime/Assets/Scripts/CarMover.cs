using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    public LayerMask mask;

    void Start()
    {
       
        // Keep a note of the time the movement started.
        //startTime = Time.time;

        // Calculate the journey length.
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * 10f;
        // Distance moved = time * speed.
        //float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        //float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers and pingpong the movement.
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));
    }

    private void OnCollisionEnter (Collision Collision)
    {
        if((mask.value& (1<<Collision.transform.gameObject.layer))>0)
        {
            Debug.Log("worked");
            GetComponent <Rigidbody>().AddForce((transform.up + Collision.transform.forward)* 10, ForceMode.Impulse);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(this);
        }
            
    }
}
