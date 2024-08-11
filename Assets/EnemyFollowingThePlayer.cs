using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingThePlayer : MonoBehaviour
{
    public Vector3 originalTransform;
    public Vector3 currentTransform;
    public float distanceToPlayer;

    public Transform playerTransform;
    public int playerHealth = 5;
    public bool isMoving = true;

    void Start()
    {
        originalTransform = this.transform.position;
        currentTransform = originalTransform;
    }

    void Update()
    {
        if(isMoving && playerHealth > 0)
        {
            MoveTowardsPlayers();
        }
    }


    public void MoveTowardsPlayers()
    {

        if(playerHealth < 0)
        {
            playerHealth = 0;
        }

           Vector3 newPosition = transform.position;
            newPosition.x = (playerTransform.position.x - 1) ;
            transform.position = newPosition;
      
    }
}
