using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnailMoving : MonoBehaviour
{
    [Header("SnailMoving")]
    public GameObject pointA;
    public GameObject pointB;
    public Transform currentPoint;

    public int enemyAttackDamage;
    public float enemySpeed;
    public float normalSpeed;

    Animator ani;
    private Rigidbody2D body;
    private SpriteRenderer render;
    void Start()
    {
        currentPoint = pointA.transform;
        enemyAttackDamage = 1;
        enemySpeed = normalSpeed * 2;

        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            body.velocity = new Vector2(enemySpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(-enemySpeed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            SnailFlip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            SnailFlip();
            currentPoint = pointB.transform;
        }

    }

    private void SnailFlip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
