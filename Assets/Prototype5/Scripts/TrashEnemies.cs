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

    GameManager6 GM6;
    GameManager5 GM5;

    Collider2D col;
    Collider col2;
    void Start()
    {
        GM5 = FindAnyObjectByType<GameManager5>();
        GM6 = FindAnyObjectByType<GameManager6>();
        col = GetComponent<Collider2D>();
        col2 = GetComponent<Collider>();

        switch (newEnemyType)
        {
            case newEnemyType.dustWarm:
                {
                    score = 5;
                }
                break;

            case newEnemyType.paperWarm:
                {
                    score = 10;
                }
                break;

            case newEnemyType.plasticWarm:
                {
                    score = 15;

                }
                break;

            case newEnemyType.canWarm:
                {
                    score = 30;

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

                }
                break;

            case newEnemyType.dustWarm:
                {
                   
                }
                break;

        }
    }

    public void TakeDamage(int damage)
    { 
        ani.SetTrigger("turnRed");
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            col.enabled = false;
            ani.SetTrigger("Death");
        }

    }

    public void TakeDamage2(int damage)
    {
        //for dustwarm only
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            col2.enabled = false;
            ani.SetTrigger("Death");
        }
    }

    public void Death()
    {
        GM5.GetScore1(score);
        Destroy(this.gameObject);

    }

    public void Death2()
    {
        GM6.GetScore1(score);
        Destroy(this.gameObject);

    }

}
