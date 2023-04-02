using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            AudioManager.Instance.PlaySFX("Player Death SFX");
        }
    }

    void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
