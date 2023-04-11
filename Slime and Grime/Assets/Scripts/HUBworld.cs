using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUBworld : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("c"))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene   
        }

    }
}
