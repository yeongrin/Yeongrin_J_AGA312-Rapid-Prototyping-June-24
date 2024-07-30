using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPlatform : MonoBehaviour
{
    EquationGenerator2 EG2;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();

    }
   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "CorrectAnswer")
        {
            EG2.isCorrectAnswer = true;
            if (EG2.isCorrectAnswer == true)
            {
                Debug.Log("correct!!");
            }

        }
    }
}
