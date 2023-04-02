using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GummiDeath : MonoBehaviour
{
    public GameObject loseScreen;
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            ShowLoseScreen();
            AudioManager.Instance.StopMusic();
        }
    }

    void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
