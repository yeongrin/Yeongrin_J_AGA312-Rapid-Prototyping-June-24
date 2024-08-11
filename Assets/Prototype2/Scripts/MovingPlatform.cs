using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    private Rigidbody2D body;

    public float currentTime;
    public float time;
    public bool movingToB = true;

    void Start()
    {
       
    }
   
    void Update()
    {
        if (movingToB)
        {
            currentTime += Time.deltaTime * speed;
            if (currentTime >= 1.0f)
            {
                currentTime = 1.0f;
                movingToB = false;
            }
        }
        else
        {
            currentTime -= Time.deltaTime * speed;
            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f;
                movingToB = true;
            }

        }
        transform.position = Vector3.Lerp(pointA.position, pointB.position, currentTime);
    }
}
