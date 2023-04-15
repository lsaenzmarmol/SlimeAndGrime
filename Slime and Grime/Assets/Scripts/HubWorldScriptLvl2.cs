using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubWorldScriptLvl2 : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           AudioManager.Instance.StopMusic();
           AudioManager.Instance.PlaySFX("Menu Select");
           BackToHubworld();
        }
    }

    void BackToHubworld()
    {
        SceneManager.LoadScene(1);
    }
}
