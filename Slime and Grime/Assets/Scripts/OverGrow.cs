using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGrow : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Overgrow"))
        {
            other.gameObject.SetActive(false);
            transform.localScale = new Vector3 (3f, 3f, 3f);

            anim.SetBool("isGrowing", true);
        }
           
    }

}
