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

    [Header("SufflePlatform")]
    public Transform[] platforms; // Assign these in the inspector
    public Vector3[] objectToPlace;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();

        objectToPlace = new Vector3[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            objectToPlace[i] = platforms[i].position;
            //This is working.
        }

        if (platform.CompareTag("WrongAnswer"))
        {
            inCorrect = EG2.dummyAnswers[0];
         
        }
        if (platform2.CompareTag("WrongAnswer2"))
        {
            inCorrect2 = EG2.dummyAnswers[1];
         
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
        //Only objects with the correct answer tag have "int = correct answer".

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

    public Vector3[] GetObjectPositions()
    {
        return objectToPlace;
        Debug.Log("8474389778946789467845897348794387943879");
        //This is not working.
    }
}
