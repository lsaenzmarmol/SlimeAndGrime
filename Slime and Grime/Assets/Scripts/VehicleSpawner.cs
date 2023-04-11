using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject VehicleSpawnPoint;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
