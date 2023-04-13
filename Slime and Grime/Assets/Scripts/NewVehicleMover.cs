using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVehicleMover : MonoBehaviour
{
    public LayerMask collisionMask;
    public int carDespawn = 10;
    public float speed = 20f;
    public float knockbackForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.forward * speed;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < speed)
        {
            rb.velocity = -transform.forward * speed;
        }
        Destroy(this.gameObject, carDespawn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collisionMask.value & 1 << collision.gameObject.layer) > 0)
        {
            Vector3 knockbackDirection = transform.position - collision.contacts[0].point;
            knockbackDirection = knockbackDirection.normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}
