using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    private Vector3 enemyPosition;
    private Vector3 newPosition;
    private readonly Vector3 offset = new Vector3(0, 0, -10);
    private readonly float speed = 0.1f;

    private void FixedUpdate()
    {
        GoToEnemy();
    }

    private void GoToEnemy()
    {
        // This sets the position of the camera to the position of the player
        // Lerp is used because this makes the camera move over time making the movement smoother
        enemyPosition = GameObject.FindGameObjectWithTag("Enemy").transform.position + offset;
        newPosition = Vector3.Lerp(transform.position, enemyPosition, speed);
        transform.position = newPosition;
    }
}
