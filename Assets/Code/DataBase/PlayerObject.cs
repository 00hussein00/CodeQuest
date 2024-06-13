using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerObject{
    //main info
    public string playerName = "";  // player name for the player object 
    public string playerMajor = " ";    // player major for the player object
    public int level = 1; // level of the player object

    //second info
    public string Rank;  // rank of the player object
    public int Score ;  // score of the player object
    public int totalSolved; // total number of solutions 
    public int totalErrors; // total number of errors
    public int accuracyRate; // accuracy rate of the player object


    
    public PlayerObject(PlayerData P)
    {
        
        playerName = P.playerName;
        playerMajor = P.playerMajor;
        level = P.level;
        Score = P.Score;
        Rank = P.Rank;
        totalSolved = P.totalSolved;
        totalErrors = P.totalErrors;
        accuracyRate = P.accuracyRate;

        Debug.Log("loaded data in player class for the account " + playerName);
    }
}
