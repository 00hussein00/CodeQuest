using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using Debug = UnityEngine.Debug;
public class getInput : MonoBehaviour
{
    // to hide log in
    static bool flagName;

    static bool flagMajor;
    static bool flagJustLogin;

    public static string sendPlayerName;


    public GameObject messagesBox;
    public Text messagesBoxText;

    // create object to save data
    PlayerData playerData = new PlayerData();
    public allSound allsound;

    

    

    // ----------------------------------------------------------------
    void Start(){
        allsound = FindObjectOfType<allSound>(); // creat object
        flagJustLogin = false;
        flagMajor = false;
        flagName = false;
    }

    // ---------------------------------------------------------------- //
    // create new account for Player
    // start ----------------------------------------------------------------
    public void newAccount(string s)
    {
        if(s == "")
        {
            Debug.Log("Empty Name");
            //showErrorBox("Empty name");
            flagName = false;
        }else if(s.Length < 4 ){
           // Debug.Log("Name too short");
            showErrorBox("Name too short , must be at least 4 characters");
            flagName = false;
        }
        else{
            try{
                string TempName =  Regex.Replace(s, "[^0-9a-z_]", "");
                if(TempName != s){
                    //Debug.Log("Cant create player Account "+ s + " after Edit " + TempName);
                    showErrorBox("Invalid username ( "+ s + " )"); // recommended ( " + TempName +" )");
                    flagName = false;

                }else{
                    playerData.newAccount(TempName);
                    flagName = true;
                    sendPlayerName =TempName;
                    Debug.Log("create player Account "+TempName );
                }
            }catch(Exception e){
                //Debug.Log(e.Message);
                showErrorBox(e.Message);
            }
        }  
    }

    public void getMajor(string s)
    {
        if(s == "")
        {   Debug.Log("Empty Major");
            //showErrorBox("Empty Major");
            flagMajor = false;
        }else{
            playerData.setMajor(s);
            flagMajor = true;
            //Debug.Log("new player Major "+ s);
        }
    }
    // End ----------------------------------------------------------------
    // ---------------------------------------------------------------- //



    // ---------------------------------------------------------------- //
    // open account for Player
    // start ----------------------------------------------------------------
    public void openAccount(string s)
    {
        if(s == "")
        {
            Debug.Log("Empty name");
            //showErrorBox("Empty name");
            flagName = false;
        }else{
            try{ 
                string TempName =  Regex.Replace(s, "[^0-9a-z_]", "");
                if(TempName != s){
                    //Debug.Log("Cant opne player Account "+ s + " after Edit " + TempName);
                    showErrorBox("Invalid username ( "+ s + " )"); 
                    flagJustLogin = false;


                }else{
                    sendPlayerName = Regex.Replace(s, "[^0-9a-z_]", "") ;
                    playerData.loadData(sendPlayerName);
                    flagJustLogin = true;
                    Debug.Log("open player "+ playerData.playerName);
                }
            }
            catch(Exception e){   // account not found
                showErrorBox(e.Message);
                //Debug.Log("Account not found " + e.ToString());
            }
        }
    }

    // End ----------------------------------------------------------------
    // ---------------------------------------------------------------- //


    // ----------------------------------------------------------------
    // to show error message
    // start ----------------------------------------------------------------
    public void showErrorBox(string s)
    {
        messagesBox.gameObject.SetActive(true);
        allsound.ShowError();
        messagesBoxText.text = s;
    }
    public void hideErrorBox() // fix button click
    {
        
        messagesBox.gameObject.SetActive(false);
    }
    // End ----------------------------------------------------------------
    // ---------------------------------------------------------------- //


    // ----------------------------------------------------------------
    // validate player name and major
    public bool checkInputFill()
    {
        if (flagMajor && flagName){
            flagMajor = false;
            flagName = false;
            return true;
        }
          
        else if (flagJustLogin){
            flagJustLogin = false;
            return true;
        }
        this.showErrorBox("Can't GO , Please enter the player information, or check if the data is valid");
        Debug.Log("Checking input fill is not supported ");
        return false;   
    }

    
    // ----------------------------------------------------------------
}