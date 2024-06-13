using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class response : MonoBehaviour
{
    [Header("------------- theLine  --------------")]
    //resspown player
    public Transform responseLine;
    [Header("------------- resspown player --------------")]
    //resspown player
    public Transform K0;
    public Transform K1;
    public Transform K2;
    int numOfK;
    // Update is called once per frame
    void Update()
    {
        numOfK = Question.numOfK;
        if (transform.position.y < responseLine.position.y)
        {
            if (numOfK == 0)
                transform.position = K0.position;
            else if (numOfK == 1)
                transform.position = K1.position;
            else if (numOfK == 2 || numOfK == 3)
                transform.position = K2.position;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D C)
    {
        if (C.gameObject.tag == "Die")
        {
            transform.position = K2.position;
        }
    }

}
