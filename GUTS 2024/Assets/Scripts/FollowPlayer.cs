using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 playerPosition;
    private Vector3 newPosition;
    private readonly Vector3 offset = new Vector3(0, 0, -10);
    private readonly float speed = 0.1f;

    private void FixedUpdate()
    {
        GoToPlayer();
    }

    private void GoToPlayer()
    {
        // This sets the position of the camera to the position of the player
        // Lerp is used because this makes the camera move over time making the movement smoother
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
        newPosition = Vector3.Lerp(transform.position, playerPosition, speed);
        transform.position = newPosition;
    }
}
