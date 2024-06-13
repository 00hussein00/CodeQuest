using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ground : MonoBehaviour
{
    public Transform PosA, PosB; // Positions between which the ground moves
    public int speed; // Speed at which the ground moves
    Vector2 targetPos; // Target position for the ground to move towards

    // Start is called before the first frame update
    void Start()
    {
        targetPos = PosB.position; // Initialize the target position to PosB
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ground is close to PosA
        if (Vector2.Distance(transform.position, PosA.position) < 0.1f)
        {
            targetPos = PosB.position; // Set target position to PosB
        }
        // Check if the ground is close to PosB
        if (Vector2.Distance(transform.position, PosB.position) < 0.1f)
        {
            targetPos = PosA.position; // Set target position to PosA
        }
        // Move the ground towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform; // Make the player a child of the ground to move with it
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null; // Remove the player as a child of the ground
        }
    }
}
