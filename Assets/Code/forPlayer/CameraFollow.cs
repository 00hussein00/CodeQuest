using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // player position in world space on the camera


    void Update()
    {
        transform.position = new Vector3(player.position.x , player.position.y + 2, -10);  // position in world space on the camera in the direction of the player in the direction
    }
}


