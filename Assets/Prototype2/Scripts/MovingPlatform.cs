using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Transform currentPoint;
    private Rigidbody2D body;

    public float speed;
    void Start()
    {
        currentPoint = pointA.transform;
        body = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            body.velocity = new Vector2(speed, 0);
        }
        else
        {
            body.velocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
          
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
         
            currentPoint = pointB.transform;
        }
    }
}
