using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void backMenuBtn(){
        SceneManager.LoadScene(0);        
    }

    public void exitBtn()  
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

}
