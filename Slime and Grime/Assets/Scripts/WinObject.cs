using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinObject : MonoBehaviour
{
   public GameObject winScreen;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           ShowWinScreen();
           AudioManager.Instance.StopMusic();
           AudioManager.Instance.PlaySFX("Menu Select");
        }
    }

    void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}
