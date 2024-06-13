using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle; // Reference to the particle system for movement
    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity; // Velocity threshold to trigger movement particles
    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod; // Time period between dust formations
    [SerializeField] Rigidbody2D playerRb; // Reference to the player's Rigidbody2D

    [SerializeField] ParticleSystem fallParticle; // Reference to the particle system for falling
    [SerializeField] ParticleSystem touchParticle; // Reference to the particle system for touching an object

    float counter; // Counter to track time for dust formation
    bool isOnGround; // Flag to check if the player is on the ground

    private void Update()
    {
        counter += Time.deltaTime; // Increment the counter by the elapsed time since the last frame
        if (isOnGround & Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity) // Check if the player is on the ground and moving fast enough
        {
            if (counter > dustFormationPeriod) // Check if the counter exceeds the dust formation period
            {
                movementParticle.Play(); // Play the movement particle effect
                counter = 0; // Reset the counter
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            fallParticle.Play(); // Play the fall particle effect when the player hits the ground
            isOnGround = true; // Set the isOnGround flag to true
        }       
        if (collision.CompareTag("Ask"))
        {
            touchParticle.Play(); // Play the touch particle effect when the player collides with an object tagged "Ask"
            isOnGround = true; // Set the isOnGround flag to true
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false; // Set the isOnGround flag to false when the player leaves the ground
        }
    }
}
