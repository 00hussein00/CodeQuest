using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Amount of speed for horizontal movement
    public float speed = 0.023f;
    // Force applied for jumping
    public float jump = 300f;

    bool onG = true; // Flag to check if the player is on the ground

    SpriteRenderer SR; // Reference to the SpriteRenderer component
    Rigidbody2D RB; // Reference to the Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        RB = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        // To move left and right
        float Hoz = Input.GetAxis("Horizontal"); // Get the horizontal input
        if (Question.inViewQuestion == false)
        {
            transform.position += new Vector3(Hoz * speed, 0, 0); // Move the player horizontally
        }
        else
        {
            transform.position += new Vector3(0, 0, 0); // Keep the player stationary
        }
        flipPlayer(Hoz); // Flip the player sprite based on the movement direction

        // Jump character
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && onG)
        {
            RB.AddForce(new Vector2(0, jump)); // Apply a vertical force to jump
            onG = false; // Set onG to false as the player is now in the air
        }
    }

    // Enter collision
    private void OnCollisionEnter2D(Collision2D C)
    {
        if (C.gameObject.tag == "Ground" || C.gameObject.tag == "Ask")
        {
            onG = true; // Set onG to true as the player is on the ground
            RB.AddForce(new Vector2(0, 0)); // Reset any additional forces
        }
    }

    // To flip the character sprite
    void flipPlayer(float H)
    {
        if (H > 0)
            SR.flipX = false; // Face right
        else if (H < 0)
            SR.flipX = true; // Face left
    }
}
