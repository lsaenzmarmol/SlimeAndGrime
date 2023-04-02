using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseObject : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.Instance.PlayMusic("Menu Music");
    }

    public void QuiteGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    } 
}
