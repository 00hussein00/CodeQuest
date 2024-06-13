using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Chat : MonoBehaviour
{
    [Header("------------- Question --------------")]
    // Reference to chat UI elements
    public GameObject Chat1;
    public GameObject Chat1C;

    public GameObject Chat2;
    public GameObject Chat2C;

    public GameObject Chat3;
    public GameObject Chat3C;

    // Called when the Collider2D other enters the trigger (2D physics only)
    private void OnCollisionEnter2D(Collision2D C)
    {   
        // Activate Chat1 UI when colliding with an object tagged "chat1"
        if (C.gameObject.tag == "chat1")
        {
           Chat1.gameObject.SetActive(true);
           Debug.Log("Chat is active ");
        }

        // Activate Chat2 UI when colliding with an object tagged "Chat2"
        if (C.gameObject.tag == "Chat2")
        {
           Chat2.gameObject.SetActive(true);
           Debug.Log("Chat is active ");
        }

        // Activate Chat3 UI when colliding with an object tagged "chat3"
        if (C.gameObject.tag == "chat3")
        {
            Chat3.gameObject.SetActive(true);
            Debug.Log("Chat is active ");
        }
    }
    
    // Called when the Collider2D other has stopped touching the trigger (2D physics only)
    private void OnCollisionExit2D(Collision2D C)
    {
        // Deactivate and destroy Chat1 UI and related game object when exiting collision with an object tagged "chat1"
        if (C.gameObject.tag == "chat1")
        {
            Destroy(C.gameObject);
            Destroy(Chat1C.gameObject);
            //Chat1.gameObject.SetActive(false);
        }

        // Deactivate and destroy Chat2 UI and related game object when exiting collision with an object tagged "Chat2"
        if (C.gameObject.tag == "Chat2")
        {
            Destroy(C.gameObject);
            Destroy(Chat2C.gameObject);
        }

        // Deactivate and destroy Chat3 UI and related game object when exiting collision with an object tagged "chat3"
        if (C.gameObject.tag == "chat3")
        {
            Destroy(C.gameObject);
            Destroy(Chat3C.gameObject);
        }
    }
}
