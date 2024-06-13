using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Animation : MonoBehaviour
{
    Animator An; 
    // Start is called before the first frame update
    void Start()
    {
        An = GetComponent<Animator>(); // Get the animator instance from the scene manager  
    }
    // Update is called once per frame
    void Update()
    {
        float hoz = Input.GetAxis("Horizontal"); // Get the current horizontal position of the animation

        if (hoz != 0)
        {
            An.SetBool("run", true); // Set the animation to run 
        }
        else
        {
            An.SetBool("run", false); // Set the animation to run 
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            An.SetTrigger("jump"); // Set the animation to jump 
        }
    } 
}
