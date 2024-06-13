using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Debug = UnityEngine.Debug;


public class PlayerState : MonoBehaviour
{
    PlayerData playerData = new PlayerData();
    string playerName = getInput.sendPlayerName;


    [Header("------------- lbl --------------")]    
    // calculate Accuracy  
    public Text lblAccurancyRate;
    int accurancyRate;
    
    // Calculates Solved
    public Text lblSolved;
    int solved;

    // Calculates Errors
    public Text lblErrors;
    int errors;

    // Calculates Score
    public Text lblScore;
    int score;


    // falg 
    public static bool showOneTime;

    // Start is called before the first frame update
    void Start()
    {
        showOneTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Question.endLevel || TimerLevel.EndTime ) && showOneTime)
        {
            
            showOneTime = false;
            // ----------------------------------------------------------------
            // to get the value of the variable
            solved = Question.numOfK;
            errors = Question.falseA;

            // ----------------------------------------------------------------
            // Accuracy
            try{
                accurancyRate = (solved * 100) / (solved + errors);
                //Debug.LogWarning(solved.ToString() + " OF " + errors.ToString());
            }catch(Exception e){
                //Debug.Log(e.ToString());
                accurancyRate = 0;
            }
            lblAccurancyRate.text = accurancyRate.ToString() + "%";

            // ----------------------------------------------------------------
            // Solved
            lblSolved.text = solved.ToString() + " OF 3 ";
            solved = solved + int.Parse(playerData.getTotalSolved(playerName));
            playerData.setTotalSolved(solved);

            // ----------------------------------------------------------------
            // Errors
            lblErrors.text = errors.ToString() + " OF 3 ";
            errors = errors + int.Parse(playerData.getTotalErrors(playerName));
            playerData.setTotalErrors(errors);


            // ----------------------------------------------------------------
            // Score 
           
            score = (solved * 79) - (errors * 30); // must add time
            if (score < 0)
                score = 0;

            lblScore.text = score.ToString();
            score = score + int.Parse(playerData.getScore(playerName));
            playerData.setScore(score);


            // ----------------------------------------------------------------

        }
    }
} 
