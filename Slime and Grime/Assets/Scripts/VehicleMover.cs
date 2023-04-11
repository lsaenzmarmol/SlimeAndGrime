using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMover : MonoBehaviour
{
    public LayerMask mask;
    public int carDespawn = 5;
    public int carSpeed = 10;

    void Start()
    {
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * carSpeed;
        Destroy(this.gameObject, carDespawn);
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
