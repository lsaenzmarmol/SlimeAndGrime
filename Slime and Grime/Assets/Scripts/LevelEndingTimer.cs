using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEndingTimer : MonoBehaviour
{
    public GameObject objectToAppear; // The game object to appear when the timer runs out
    public TextMeshProUGUI timerText; // The TextMeshPro object to display the timer on screen
    private float timer = 60f; // The timer duration in seconds
    public bool startTimerOnLoad = true; // Whether to start the timer automatically when the scene loads

    void Start()
    {
        if(startTimerOnLoad)
        {
            enabled = true; // Enable this script so it starts running
        }
    }

    void Update()
    {
        timer -= Time.deltaTime; // Decrease the timer by the time since the last frame
        if (timer <= 0f)
        {
            objectToAppear.SetActive(true); // Activate the game object
            timerText.text = "0.00"; // Update the timer text to show that the timer has run out
            enabled = false; // Disable this script so it doesn't keep running
        }
        else
        {
            timerText.text = timer.ToString("F2"); // Update the timer text to show the current timer value
        }
    }   
}
