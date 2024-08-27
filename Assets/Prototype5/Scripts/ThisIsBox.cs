using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsBox : MonoBehaviour
{
    public int boxDefense;
    public Animator ani;

    void Start()
    {

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
            Destroy(this.gameObject);
        }

    }
}
