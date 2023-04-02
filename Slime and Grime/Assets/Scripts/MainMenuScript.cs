using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

    public void GoToOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");

    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
