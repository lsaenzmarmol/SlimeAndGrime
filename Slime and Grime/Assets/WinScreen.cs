using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
       
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
