using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingThePlayer : MonoBehaviour
{
    public Vector3 originalTransform;
    public Vector3 currentTransform;
    public float distanceToPlayer;

    void Start()
    {
        originalTransform = this.transform.position;
        currentTransform = originalTransform;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController4.playerHealth <= 4)
        {
            for (int i = 0; i < 1; i++)
            {
                currentTransform = new Vector3(originalTransform.x + 5, originalTransform.y);
                transform.position = Vector3.Lerp(originalTransform, currentTransform, 0f);
                originalTransform = currentTransform;
                break;
            }
            if (PlayerController4.playerHealth <= 3)
            {
                currentTransform = new Vector3(originalTransform.x + 5, originalTransform.y);
                originalTransform = currentTransform;

                if (PlayerController4.playerHealth <= 2)
                {
                    currentTransform = new Vector3(originalTransform.x + 5, originalTransform.y);
                    originalTransform = currentTransform;

                    if (PlayerController4.playerHealth <= 1)
                    {
                        currentTransform = new Vector3(originalTransform.x + 5, originalTransform.y);
                        originalTransform = currentTransform;

                    }
                }
            }
        }
            
        
    }
}
