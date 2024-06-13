using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Debug = UnityEngine.Debug;

public class Pages : MonoBehaviour
{
    //the Help 
    [Header("------------- Page --------------")]
    public GameObject youLoss;
    public GameObject youWin;
    public GameObject Playerstate;
    public GameObject canvesPlayerData;
    public GameObject aboutLevel;
    public GameObject StopMenu;
    private ButtonControl btnctrl;

    PlayerData playerData = new PlayerData();
    public static string playerName = getInput.sendPlayerName;
    int numOfCurentLevel;
    bool callFunction; // to call the function one time
    bool flagShowStopMenuPage = false; // to 



    // ----------------------------------------------------------------    
    // Start stop menu
        public void showStopMenuPage()
        {
            StopMenu.gameObject.SetActive(true);
            canvesPlayerData.gameObject.SetActive(false);
        }
        public void HideStopMenuPage()
        {
            StopMenu.gameObject.SetActive(false);
            canvesPlayerData.gameObject.SetActive(true);
        }
        public void resum()
        {
            HideStopMenuPage();
            Time.timeScale = 1f;
        }
        public void restart()
        {
            Time.timeScale = 1f;
            numOfCurentLevel = int.Parse(playerData.getLevel(playerName));
            SceneManager.LoadScene(numOfCurentLevel);
        }
        public void Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    
    // ----------------------------------------------------------------
    // Start player Question (show , Answer)

        public void PlayerAnswer()
        {
            canvesPlayerData.gameObject.SetActive(true);
        }
        public void showQuestion()
        {
            canvesPlayerData.gameObject.SetActive(false);
        } 


    // ----------------------------------------------------------------
    // Start player Win
        public void PlayerWin()
        {
            youWin.gameObject.SetActive(true);
            canvesPlayerData.gameObject.SetActive(false);
            Playerstate.gameObject.SetActive(true);
            Time.timeScale = 0f;
            playerData.NextLevel();
            
        }
        public void youWinNextLevel()
        {
            numOfCurentLevel = playerData.level;
            SceneManager.LoadScene(numOfCurentLevel);
            Time.timeScale = 1f;
        }

    // ----------------------------------------------------------------
    // Start player Loss
    public void PlayerLoss()
        {
            youLoss.gameObject.SetActive(true);
            canvesPlayerData.gameObject.SetActive(false);
            Playerstate.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    public void youLossRetry()
        {
            playerName = getInput.sendPlayerName;
            youLoss.gameObject.SetActive(false);
            numOfCurentLevel = int.Parse(playerData.getLevel(playerName));    
            SceneManager.LoadScene(numOfCurentLevel);
            Time.timeScale = 1f;
    }

    // ----------------------------------------------------------------
    // Start About Level 
    public void showAboutLevelPage()
        {
            aboutLevel.gameObject.SetActive(true);
            canvesPlayerData.gameObject.SetActive(false);
            flagShowStopMenuPage = false;
        }
            public void hideAboutLevelPage()
        {
            aboutLevel.gameObject.SetActive(false);
            canvesPlayerData.gameObject.SetActive(true);
            flagShowStopMenuPage = true;
        }
    
    // ----------------------------------------------------------------







    


    // ----------------------------------------------------------------
    // MAin function ----------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        //P.SetLevel();
        showAboutLevelPage();
        playerName = getInput.sendPlayerName;
        callFunction = true;
    }

    // Update is called once per frame
    void Update()
    {
        // to show stop menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Question.inViewQuestion && flagShowStopMenuPage){
                showStopMenuPage();
                Time.timeScale = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && callFunction)
        {
            callFunction = false;
            hideAboutLevelPage();
            Time.timeScale = 1f;
        }
    }
}
