using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerLevel : MonoBehaviour
{
    public Pages pages; // Reference to Pages component
    public allSound allsound; // Reference to allSound component

    bool inTask = false; // Flag to start the timer after hiding the task
    bool callFunction = true; // Flag to call a function only once

    public float timeForLevel = 140f; // Total time allowed for the level

    [SerializeField] TextMeshProUGUI timerText; // Text to display the timer
    float remainingTime; // Remaining time for the level
    float remainingTime2; // Backup of the initial time for the level

    public static bool EndTime = false; // Flag to indicate if time has ended

    // Initialization
    void Start()
    {
        pages = FindObjectOfType<Pages>(); // Find Pages component in the scene
        remainingTime = timeForLevel; // Initialize remaining time for the level
        remainingTime2 = timeForLevel; // Backup of the initial time for the level
        remainingTime = remainingTime2; // Reset remaining time

        allsound = FindObjectOfType<allSound>(); // Find allSound component in the scene

        EndTime = false; // Reset end time flag
        inTask = false; // Reset in task flag
        callFunction = true; // Reset call function flag
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && callFunction)
        {
            callFunction = false; // Ensure the function is called only once
            inTask = true; // Start the task
        }
        if (inTask)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime; // Decrease remaining time

                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format(" {0:00}:{1:00}", minutes, seconds); // Update timer text
            }
            else
            {
                remainingTime = 0; // Set remaining time to zero
                pages.PlayerLoss(); // Handle player loss scenario
                allsound.soundYouLoss(); // Play loss sound
                EndTime = true; // Set end time flag
                timerText.text = " 00:00"; // Display 00:00 when time runs out
                inTask = false; // End the task
            }
        }
    }
}
