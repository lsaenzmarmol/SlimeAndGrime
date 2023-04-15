using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject Vehicle;  // The GameObject to instantiate.
    public float Delay = 3f;     // The delay between instantiations.

    void Start()
    {
        // Start invoking the InstantiateObject() method with the specified delay.
        InvokeRepeating("InstantiateObject", Delay, Delay);
    }

    void InstantiateObject()
    {
        // Instantiate the objectToInstantiate at the current position and rotation of this GameObject.
        Instantiate(Vehicle, transform.position, transform.rotation);
    }
}
