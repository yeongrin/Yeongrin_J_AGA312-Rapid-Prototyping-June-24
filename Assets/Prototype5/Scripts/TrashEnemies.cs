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

    GameManager5 GM5;

    void Start()
    {
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
            ani.SetTrigger("Death");
        }

    }

    public void Death()
    {
        GM5.GetScore1(score);
        Destroy(this.gameObject);

    }

}
