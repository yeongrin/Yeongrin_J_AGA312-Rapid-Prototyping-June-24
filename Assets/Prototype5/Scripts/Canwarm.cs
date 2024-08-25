using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canwarm : MonoBehaviour
{
    public newEnemyType newEnemyType;
    public int enemyHealth;
    public int score;
    public Animator ani;

    [Header("OnlyForCanWarm")]
    private Rigidbody rb;
    public GameObject rightCheck, roofCheck, groundCheck;
    public LayerMask groundlayer, wall;
    private bool facingRight = true, groundTouch, roofTouch, rightTouch;
    public float dirX = 1, dirY = 0.5f;
    public float speed, circleRadius;

    GameManager5 GM5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GM5 = FindAnyObjectByType<GameManager5>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        rb.velocity = new Vector2(dirX, dirY) * speed * Time.deltaTime;
        HitDirection();
    }

    void HitDirection()
    {
        rightTouch = Physics.CheckSphere(rightCheck.transform.position, circleRadius, groundlayer);
        roofTouch = Physics.CheckSphere(roofCheck.transform.position, circleRadius, groundlayer);
        groundTouch = Physics.CheckSphere(groundCheck.transform.position, circleRadius, groundlayer);
        HitLogic();
       
    }

    void HitLogic()
    {
        if (rightTouch && facingRight)
        {
            Flip();
       
        }
        else if (rightTouch && !facingRight)
        {
            Flip();
          
        }
        if (roofTouch)
        {
            dirY = -0.5f;
         
        }
        else if (groundTouch)
        {
            dirY = 0.5f;
          
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