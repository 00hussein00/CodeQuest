using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Debug = UnityEngine.Debug;

public class ShowState : MonoBehaviour
{   
    public string PlayerName ;
    public bool showOneTime = true;

    [Header("------------- LBL --------------")]
    public Text lblNameState;
    public Text lblNumLevel;


    public Text lblTotalAttempts;
    public Text lblTotalSolved;
    public Text lblTotalError;
    public Text lblAccuracyRate;
    public Text lblScore;
    public Text lblRank;



    PlayerData playerData = new PlayerData();

    void Start(){
        // reset after click log out
        showOneTime = true;
    }

    // Update is called once per frame
    void Update()
    {            
       // PlayerName = getInput.sendPlayerName;

        if (ButtonControl.enabledShowState && showOneTime && PlayerName != null){
            
            // to load data 
                PlayerName = getInput.sendPlayerName;
                playerData.loadData(PlayerName);
            // ----------------------------------------------------------------
            // to show name state
                lblNameState.text = PlayerName;            

            //P.setTotalSolved(0);
            // ----------------------------------------------------------------
            // to show Level state
                lblNumLevel.text = playerData.getLevel(PlayerName);

            // ----------------------------------------------------------------
            // to show total solved
                lblTotalSolved.text = playerData.getTotalSolved(PlayerName);

            // ----------------------------------------------------------------
            // to show total Error
                lblTotalError.text = playerData.getTotalErrors(PlayerName);
            
            // ----------------------------------------------------------------
            // to show Accuracy rate
                try{
                    playerData.setAccuracyRate((int.Parse(playerData.getTotalSolved(PlayerName)) * 100) / (int.Parse(playerData.getTotalSolved(PlayerName)) + int.Parse(playerData.getTotalErrors(PlayerName))));
                }catch(Exception e){
                    playerData.setAccuracyRate(0);
                    Debug.Log(e.Message);
                }
                lblAccuracyRate.text = playerData.getAccuracyRate(PlayerName) + "%";                
                


            // ----------------------------------------------------------------
            // to show Score
                lblScore.text = playerData.getScore(PlayerName);
            
            // ----------------------------------------------------------------
            // to show rank
                int getRank = int.Parse(playerData.getScore(PlayerName));
                if (getRank < 100)
                    lblRank.text = "F";
                else if (getRank >= 100 && getRank < 500)
                    lblRank.text = "D";
                else if (getRank >= 500 && getRank < 1000)
                    lblRank.text = "C";
                else if (getRank >= 1000 && getRank < 2000)
                    lblRank.text = "B";
                else if (getRank >= 2000 && getRank < 5000)
                    lblRank.text = "A";
                else if (getRank >= 5000 && getRank < 10000)
                    lblRank.text = "S";
                else if (getRank >= 10000 && getRank < 20000)
                    lblRank.text = "SS";
                else if (getRank >= 20000 && getRank < 50000)
                    lblRank.text = "SSS";
                else if (getRank >= 50000 && getRank < 100000)
                    lblRank.text = "SSSS";
                else
                    lblRank.text = "SSSSS"; 
     



            // ----------------------------------------------------------------
            

            
            // ----------------------------------------------------------------
            // reset values
                showOneTime = false;
        }
    }
}
