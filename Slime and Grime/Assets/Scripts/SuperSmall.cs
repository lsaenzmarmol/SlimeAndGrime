using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSmall : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Super Small"))
        {
            other.gameObject.SetActive(false);
            transform.localScale = new Vector3 (.5f, .5f, .5f);
        }
    }



}
