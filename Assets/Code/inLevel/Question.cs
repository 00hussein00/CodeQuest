using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System;

public class Question : MonoBehaviour
{
    // General
    public static int randomQ;  // Randomly selected question index
    Collision2D delKarean = new Collision2D(); // To remove a specific Karen

    // Components
    public Pages pages; // Reference to Pages component
    public allSound allsound; // Reference to allSound component

    // Question Objects
    [Header("------------- Question --------------")]
    public GameObject[] AllQ1 = {}; // Array of all question GameObjects

    // Labels
    [Header("------------- LBL --------------")]
    public Text lblNumOfKaren; // Label to display the number of Karens
    public GameObject lblClickSpace; // Label to prompt player to click space
    public Text falseAnswer; // Label to display the number of incorrect answers

    // Time Variables
    [Header("------------- Time --------------")]
    public float timeForQuestion = 30f; // Time allowed for answering a question
    [SerializeField] TextMeshProUGUI timerText; // Text to display the timer
    float remainingTime; // Remaining time for the current question
    float remainingTime2; // Backup of the initial time for a question

    // Flags
    [Header("------------- Flags --------------")]
    public static bool inViewQuestion = false; // Flag to indicate if a question is being viewed
    bool FlagQuestion = true; // Flag to prevent getting a new random number repeatedly
    public static bool endLevel = false; // Flag to indicate the end of the level
    bool callFunction = true; // Flag to ensure a function is called only once

    // Counters
    public static int numOfK; // Number of Karens collected
    public static int falseA; // Number of incorrect answers

    // Initialization
    void Start()
    {
        remainingTime = timeForQuestion; // Initialize remaining time for the question
        remainingTime2 = timeForQuestion; // Backup of the initial time for a question

        // Find Objects
        pages = FindObjectOfType<Pages>(); // Find Pages component in the scene
        allsound = FindObjectOfType<allSound>(); // Find allSound component in the scene

        // Reset Values
        remainingTime = remainingTime2; // Reset remaining time
        falseA = 0; // Reset incorrect answers count
        numOfK = 0; // Reset Karens collected count
        endLevel = false; // Reset end level flag
    }

    // Update is called once per frame
    void Update()
    {
        // Timer Update
        if (inViewQuestion)
        {
            timerText.gameObject.SetActive(true); // Show timer text
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime; // Decrease remaining time
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("Remaining Time : {0:00}:{1:00}", minutes, seconds); // Update timer text
            }
            else
            {
                remainingTime = 0; // Set remaining time to zero
                F(); // Handle the false answer scenario
                timerText.text = "Remaining Time: 00:00"; // Update timer text to zero
            }
        }

        // Check for game over
        if (falseA == 3)
        {
            endLevel = true; // Set end level flag
            if (callFunction)
            {
                allsound.soundYouLoss(); // Play loss sound
                pages.PlayerLoss(); // Show player loss screen
            }
            callFunction = false; // Ensure function is called only once
        }

        // Check for game win
        if (numOfK == 3)
        {
            endLevel = true; // Set end level flag
            if (callFunction)
            {
                allsound.soundYouWin(); // Play win sound
                pages.PlayerWin(); // Show player win screen
            }
            callFunction = false; // Ensure function is called only once
        }
    }

    // On Collision Stay
    private void OnCollisionStay2D(Collision2D C)
    {
        if (C.gameObject.tag == "Ask")
        {
            lblClickSpace.gameObject.SetActive(true); // Show prompt to click space
            if (Input.GetKey(KeyCode.Space))
            {
                if (FlagQuestion)
                {
                    getNum(); // Generate a random question number
                    FlagQuestion = false; // Prevent getting a new random number repeatedly
                }
                AllQ1[randomQ].gameObject.SetActive(true); // Show the selected question
                lblClickSpace.gameObject.SetActive(false); // Hide the prompt
                delKarean = C; // Store the collision for later use
                inViewQuestion = true; // Set flag to indicate a question is being viewed
                pages.showQuestion(); // Show the question on the screen
            }
        }
    }

    // On Collision Exit
    private void OnCollisionExit2D(Collision2D C)
    {
        if (C.gameObject.tag == "Ask")
        {
            try
            {
                lblClickSpace.gameObject.SetActive(false); // Hide the prompt
            }
            catch (Exception e)
            {
                // Debug.Log("no lblClickSpace to hide it");
            }
        }
    }

    // Generate Random Number for Question
    public void getNum()
    {
        randomQ = new System.Random().Next(0, AllQ1.Length - 1); // Generate a random index for the question array
        int tempRand = randomQ + 1;
        Debug.Log("Show question number " + tempRand.ToString()); // Log the question number
    }

    // True Answer Clicked
    public void T()
    {
        allsound.trueAnswerClick(); // Play correct answer sound
        answer(); // Process the answer
        numOfK++; // Increment Karens collected count
        lblNumOfKaren.text = "Karen : " + numOfK.ToString() + " of 3 "; // Update the Karen count label
        Destroy(delKarean.gameObject); // Destroy the Karen game object
    }

    // False Answer Clicked
    public void F()
    {
        allsound.falseAnswerClick(); // Play incorrect answer sound
        answer(); // Process the answer
        falseA++; // Increment incorrect answers count
        falseAnswer.text = "Error: " + falseA.ToString() + " OF 3 "; // Update the incorrect answers label
    }

    // Process Answer
    public void answer()
    {
        AllQ1[randomQ].gameObject.SetActive(false); // Hide the answered question
        RemoveElement(ref AllQ1, randomQ); // Remove the answered question from the array
        pages.PlayerAnswer(); // Update the player answer page
        timerText.gameObject.SetActive(false); // Hide the timer text
        FlagQuestion = true; // Reset flag to allow getting a new random number
        inViewQuestion = false; // Set flag to indicate no question is being viewed
        remainingTime = remainingTime2; // Reset the remaining time for the next question
    }

    // Remove Element from Array
    void RemoveElement<T>(ref T[] A, int Q)
    {
        try
        {
            for (int i = Q; i < A.Length - 1; i++)
            {
                A[i] = A[i + 1]; // Shift elements to remove the specified element
            }
            Array.Resize(ref A, A.Length - 1); // Resize the array
        }
        catch (Exception e)
        {
            Debug.Log("anonymous Error in RemoveElement " + e.ToString()); // Log any errors
        }
    }
}
