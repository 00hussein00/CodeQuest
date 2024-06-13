using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Debug = UnityEngine.Debug;

public class PlayerData : MonoBehaviour
{
    //main info about the player 
    public string playerName = "";  // the name of the player
    public string playerMajor = " ";    // the major of the player
    public int level = 1;   // the level of the player


    // secondary info about the player 
    public int Score ;  // the score of the player
    public int totalSolved;  // the total number of solutions that have been solved 
    public int totalErrors; // the total number of errors that have been solved
    public int accuracyRate; // the accuracy rate of the player
    public string Rank; // the rank of the player




    // ----------------------------------------------------------------
    // playerName function
    public void newAccount(string m)
    {
        this.playerName = m;
        Debug.Log("Create new Account : " + this.playerName );
        newPlayer();
    }
    public string getPlayerName()
    {
        return this.playerName;
    }

    // ----------------------------------------------------------------
    // level function
    public void setLevel(int newLevel,string newPlayerName)
    {   
        loadData(newPlayerName);
        playerName = newPlayerName;
        this.level = newLevel ; 
        updatePlayerInfo();
        Debug.Log("new Level: " + this.level + " for " + this.playerName );
    }
    public void NextLevel()
    {
         playerName = getInput.sendPlayerName;
        loadData(this.playerName);
        this.level++;
        Debug.Log("Go to next level from " +  this.level.ToString() + " to " + this.level.ToString() + " for " + this.playerName);
        updatePlayerInfo();
    }

    public string getLevel(string s){
        loadData(s);
        Debug.Log("you in Level: " + this.level.ToString() + " for " + this.playerName);
        return this.level.ToString();
    }

    // ----------------------------------------------------------------
    // Major function
    public void setMajor(string m)
    {
        this.playerMajor = m;
        Debug.Log("new Major: " + this.playerMajor + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getMajor(string s)
    {
        loadData(s);
        Debug.Log("your major " + this.playerMajor + " for " + this.playerName);
        return this.playerMajor;
    }

    // ----------------------------------------------------------------
    // Score function
    public void setScore(int a)
    {
        this.Score = a;
        Debug.Log("new Score: " + this.Score + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getScore(string s)
    {
        loadData(s);
        Debug.Log("your score " + this.Score.ToString()  + " for " + this.playerName);
        return this.Score.ToString();
    }

    // ----------------------------------------------------------------
    // totalSolved function
    public void setTotalSolved(int a)
    {
        this.totalSolved = a;
        Debug.Log("new total Solved: " + this.totalSolved.ToString()  + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getTotalSolved(string s)
    {
        loadData(s);
        Debug.Log("your total Solved " + this.totalSolved.ToString()  + " for " + this.playerName);
        return this.totalSolved.ToString();
    }

    // ----------------------------------------------------------------
    // totalErrors function
    public void setTotalErrors(int a)
    {
        this.totalErrors = a;
        Debug.Log("new total Errors: " + this.totalErrors + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getTotalErrors(string s)
    {
        loadData(s);
        Debug.Log("your total Errors " + this.totalErrors.ToString()  + " for " + this.playerName);
        return this.totalErrors.ToString();
    }

    // ----------------------------------------------------------------
    // accuracyRate function
    public void setAccuracyRate(int a)
    {
        this.accuracyRate = a;
        Debug.Log("new accuracy Rate " + this.accuracyRate + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getAccuracyRate(string s)
    {
        loadData(s);
        Debug.Log("your accuracy Rate " + this.accuracyRate.ToString()  + " for " + this.playerName);
        return this.accuracyRate.ToString();
    }

    // ----------------------------------------------------------------
    // Rank function
    public void setRank(string a)
    {
        this.Rank = a;
        Debug.Log("new Rank: " + this.Rank.ToString()  + " for " + this.playerName );
        updatePlayerInfo();
    }
    public string getRank(string s)
    {
        loadData(s);
        Debug.Log("your Rank " + this.Rank.ToString()  + " for " + this.playerName);
        return this.Rank.ToString();
    }
    

    // ----------------------------------------------------------------

    void Start(){
        CreateGestAccount();
    }



    // ----------------------------------------------------------------
    // main function
    public void newPlayer()
    {
        SaveData.newAccountPlayer(this, playerName);
        Debug.Log("saved data in player class for the account " + playerName);
    }
    public void updatePlayerInfo()
    {
        SaveData.updatePlayerInformation(this, playerName);
        Debug.Log("Update data in player class for the account " + playerName);
    }

    public void CreateGestAccount()
    {
        SaveData.updatePlayerInformation(this, "gest");
        Debug.Log("Update data in player class for the account gest" );
    }
    public void saveData(string fileName)
    {
        playerName = fileName;
        SaveData.updatePlayerInformation(this, fileName);
        Debug.Log("saved data in player class for the account " + fileName);
    }

    public void loadData(string filename)
    {
        PlayerObject data = SaveData.loadPlayer(filename);
        
        // set the player information for the account
        this.playerName = data.playerName;
        this.level = data.level;
        this.Rank = data.Rank;
        this.playerMajor = data.playerMajor;
        this.Score = data.Score;
        this.totalSolved = data.totalSolved;
        this.totalErrors = data.totalErrors;
        this.accuracyRate = data.accuracyRate;
        Debug.Log("loaded data in player class for the account " + playerName);
    }
}

// new function to update
/*
    public string returnBestScore { 
        get { return this.bestScore.ToString(); }
        set { this.bestScore = int.Parse(value); }
     }
*/