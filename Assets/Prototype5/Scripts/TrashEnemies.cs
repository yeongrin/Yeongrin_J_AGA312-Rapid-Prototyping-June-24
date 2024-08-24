using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering;
using UnityEngine;

public enum newEnemyType
{
    paperWarm,
    plasticWarm,
    canWarm,
    dustWarm,
}

public class TrashEnemies : MonoBehaviour
{
    public newEnemyType newEnemyType;
    public int enemyHealth;
    public int score;
    public Animator ani;

    [Header("OnlyForCanWarm")]
    private Rigidbody2D rb;
    public GameObject rightCheck, roofCheck, groundCheck;
    public LayerMask groundlayer;
    private bool facingRight = true, groundTouch, roofTouch, rightTouch;
    public float dirX = 1, dirY = 0.25f;
    public float speed, circleRadius;

    GameManager5 GM5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM5 = FindAnyObjectByType<GameManager5>();

        switch (newEnemyType)
        {
            case newEnemyType.paperWarm:
                {
                    score = 10;
                }
                break;

            case newEnemyType.plasticWarm:
                {
                    score = 20;

                }
                break;

            case newEnemyType.canWarm:
                {
                    score = 30;
                    Moving();
                }
                break;

            case newEnemyType.dustWarm:
                {
                    score = 40;
                }
                break;

        }
    }

    void Update()
    {
        switch (newEnemyType)
        {
            case newEnemyType.paperWarm:
                {
                  
                }
                break;

            case newEnemyType.plasticWarm:
                {
                   
                }
                break;

            case newEnemyType.canWarm:
                {
                    Moving();
                }
                break;

            case newEnemyType.dustWarm:
                {
                   
                }
                break;

        }
    }

    void Moving()
    {
        rb.velocity = new Vector2(dirX, dirY) * speed * Time.deltaTime;
        HitDirection();
    }

    void HitDirection()
    {
        rightTouch = Physics2D.OverlapCircle(rightCheck.transform.position, circleRadius, groundlayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, circleRadius, groundlayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundlayer);
        HitLogic();
    }

    void HitLogic()
    {
        if(rightTouch && facingRight)
        {
            Flip();
        }
        else if(rightTouch && !facingRight)
        {
            Flip();
        }
        if(roofTouch)
        {
            dirY = -0.25f;
        }
        else if(groundTouch)
        {
            dirY = 0.25f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        dirX = -dirX;
    }

    public void TakeDamage(int damage)
    {
        ani.SetTrigger("turnRed");
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            ani.SetTrigger("Death");
        }

    }

    public void Death()
    {
        GM5.GetScore1(score);
        Destroy(this.gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rightCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(roofCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
    }
}
