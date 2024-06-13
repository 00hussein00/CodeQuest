using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class ButtonControl : MonoBehaviour
{ 
    [Header("------------- Noraml Page --------------")]
    public GameObject About;
    public GameObject Setting0;
    public GameObject mainMenu;


    [Header("------------- choose --------------")]
    public GameObject chooseWay;
    public GameObject logIn;
    public GameObject register;
        
        
    [Header("------------- warrining --------------")]

    public GameObject messagesBox;
    public Text messagesBoxText;


    [Header("------------- NULL --------------")]
    public allSound allsound;
    public static bool enabledShowState;

   // getInput getInputObj = new getInput();
    PlayerData playerData = new PlayerData();
    string PlayerName = getInput.sendPlayerName; 
    
    public getInput getInputObj;
    int numOfCurentLevel;

    
    void Start(){
        getInputObj = FindObjectOfType<getInput>(); // creat object     
        allsound = FindObjectOfType<allSound>(); // creat object   

        if (PlayerName == "gest" || PlayerName == null){
            chooseWay.gameObject.SetActive(true);
            enabledShowState = false; // not Show player information on screen if player not available
        }
        else{
            showMainmeni();
            enabledShowState = true; // Show player information on screen if player available
        }

        Debug.Log("you log in as a : " + PlayerName);
    }



    void showMainmeni(){
        mainMenu.SetActive(true);
        About.SetActive(false);
        Setting0.SetActive(false);
        chooseWay.SetActive(false);
        logIn.SetActive(false);
        register.SetActive(false);
    }

    // ------------------------------------------------ 
    // All Pages
    public void logoutBtn() 
    {
       // Debug.Log("Logout");
        PlayerName = "gest";
        getInputObj.openAccount("gest");
        SceneManager.LoadScene(0);
    }

    public void exitBtn()  // called in the main menu && chooseWay
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    public void backMenu() // called in the about && setting 
    {
        About.gameObject.SetActive(false);
        Setting0.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void backChooseWay() // called in LogIN && register && mainMenu (Log out btn)
    {
        mainMenu.gameObject.SetActive(false);
        logIn.gameObject.SetActive(false);
        register.gameObject.SetActive(false);
        chooseWay.gameObject.SetActive(true);
    }

    public void GO() // called in the register && LogIn
    {
        if (getInputObj.checkInputFill()){ 
            enabledShowState = true;
            mainMenu.gameObject.SetActive(true);
            register.gameObject.SetActive(false);
            logIn.gameObject.SetActive(false);
        }else{
            //Debug.Log("Can't Go");
        }
    }

    // ------------------------------------------------ 
    // Main Menu
    bool keepGoing;
    public void playBtn()
    {   
        PlayerName = getInput.sendPlayerName;
        int level = int.Parse(playerData.getLevel(PlayerName));
        //Debug.Log( " Level : " + level + "for player " + PlayerName);
        if (level == 1){
            SceneManager.LoadScene(1);
        }else{
            if(keepGoing){
                playerData.setLevel(1,PlayerName);
                SceneManager.LoadScene(1);
            }else{
                this.showWarriningBox("If click ok, you restart from level 1");
            }
        }
    }

    public void contenueBtn()
    {
        PlayerName = getInput.sendPlayerName;
        numOfCurentLevel = int.Parse(playerData.getLevel(PlayerName));
        SceneManager.LoadScene(numOfCurentLevel);

    }

    public void goSetting()
    {
        Setting0.gameObject.SetActive(true);
    }

    public void goAbout()
    {
        About.gameObject.SetActive(true);
    }


    // ------------------------------------------------ 
    // chooseWay 
    public void goLogIn()
    {
        logIn.gameObject.SetActive(true);
        chooseWay.gameObject.SetActive(false);
    }

    public void goRegister()
    {
        register.gameObject.SetActive(true);
        chooseWay.gameObject.SetActive(false);
    }
    public void goAsGest(){
        //enabledShowState = true;
        chooseWay.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        Debug.Log("open game with gest account");
    }
    // ------------------------------------------------ 




    // ----------------------------------------------------------------
    // to show error message
    // start ----------------------------------------------------------------
    public void showWarriningBox(string s)
    {
        allsound.ShowWarrining();
        messagesBox.gameObject.SetActive(true);
        messagesBoxText.text = s;
    }
    public void hideWarriningBox() // fix button click
    {
        messagesBox.gameObject.SetActive(false);
        keepGoing = true;
    }
    // End ----------------------------------------------------------------
    // ---------------------------------------------------------------- //
}
