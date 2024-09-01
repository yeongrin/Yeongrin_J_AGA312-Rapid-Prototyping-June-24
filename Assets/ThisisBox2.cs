using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisisBox2 : MonoBehaviour
{
    public int boxDefense;
    public Animator ani;
    public int score;

    GameManager6 GM6;

    void Start()
    {
        GM6 = FindAnyObjectByType<GameManager6>();
    }


    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        ani.SetTrigger("turnRed");
        boxDefense -= damage;

        if (boxDefense <= 0)
        {
            GM6.GetScore1(score);
            Destroy(this.gameObject);
        }

    }
}
