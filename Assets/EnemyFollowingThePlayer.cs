using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingThePlayer : MonoBehaviour
{

    public Vector3 currentTransform;

    public Transform player;
    public Transform enemy;
    public int speed;
    public bool isMoving = true;

    void Start()
    {
        currentTransform = enemy.position;
    }

    void Update()
    {
        if (PlayerController4.playerHealth <= 0)
        {
            // Make sure player and enemy are at the same position
            if (Vector3.Distance(player.position, enemy.position) > 0.1f)
            {
                enemy.position = player.position;
            }
        }
        else
        {
            // Move enemy towards the player based on strength
            MoveTowardsPlayers();
        }
    }


    public void MoveTowardsPlayers()
    {

        // Calculate the direction from enemy to player
        Vector3 direction = (player.position - enemy.position).normalized;

        // Move the enemy towards the player
        enemy.position += direction * speed * Time.deltaTime;

        // Check if the enemy has reached the player
        if (Vector3.Distance(enemy.position, player.position) < 0.1f)
        {
            // Ensure the enemy's position is exactly at the player's position
            enemy.position = player.position;
        }

    }
}
