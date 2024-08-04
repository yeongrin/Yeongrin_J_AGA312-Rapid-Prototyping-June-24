using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswerPlatform : MonoBehaviour
{
    EquationGenerator2 EG2;
    public int correct;
    public int inCorrect;
    public int inCorrect2;

    public GameObject platform;
    public GameObject platform2;
    public GameObject platform3;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();

        if (platform.CompareTag("WrongAnswer"))
        {
            inCorrect = EG2.dummyAnswers[0];
            Debug.Log("this is not the answer");
        }
        if (platform2.CompareTag("WrongAnswer2"))
        {
            inCorrect2 = EG2.dummyAnswers[1];
            Debug.Log("this is not the answer");
        }
        if(platform3.gameObject.CompareTag("CorrectAnswer"))
        {
            correct = EG2.correctAnswer;
        }

    }

   
    void Update()
    {
        ShowTheAnswer();
    }

    void ShowTheAnswer()
    {
        if (platform.CompareTag("WrongAnswer"))
        {
            inCorrect = EG2.dummyAnswers[0];
           
        }
        if (platform2.CompareTag("WrongAnswer2"))
        {
            inCorrect2 = EG2.dummyAnswers[1];
           
        }
        if (platform3.gameObject.CompareTag("CorrectAnswer"))
        {
            correct = EG2.correctAnswer;
        }

    }
}
