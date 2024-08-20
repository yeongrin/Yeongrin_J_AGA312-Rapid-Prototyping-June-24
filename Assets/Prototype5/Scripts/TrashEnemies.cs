using System.Collections;
using System.Collections.Generic;
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
    public Animator ani;

    void Start()
    {
        
    }

    void Update()
    {
        switch(newEnemyType)
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
        enemyHealth = enemyHealth - damage;

        if (enemyHealth >= 0)
        {
            ani.SetTrigger("Death");
            Destroy(this.gameObject, 7f);
        }

    }
}
