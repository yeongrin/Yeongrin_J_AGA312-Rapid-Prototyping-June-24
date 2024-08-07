using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EquationGenerator2 : MonoBehaviour
{
    //This script is question and answer script. The answer is randomly located on the platform.
    //Correct Answer must be located on a platform with the correct answer tag.

    public enum Difficulty { EASY, MEDIUM, HARD }
    public Difficulty difficulty;

    [Header("Equation")]
    public int numberOne;
    public int numberTwo;
    public int correctAnswer;  //If you choose the correct answer, move on to the next question.
    public List<int> dummyAnswers;
    public string operatorSign = "";
    public bool isCorrectAnswer; //If you collide with the right platform, this bool becomes true.

    [Header("SufflePlatform")]
    //public Transform[] platformLocation;
    //public Transform[] platforms;
    //public GameObject[] objectToPlace;

    CorrectAnswerPlatform CAP;

    void Start()
    {
        GenerateRandomQuestionSuffle1();

        GameObject player = GameObject.FindWithTag("Player");
        CAP = gameObject.GetComponent<CorrectAnswerPlatform>();

    }

    private void Update()
    {
        //Go to next question
        if (isCorrectAnswer == true)
        {
            GenerateRandomQuestionSuffle1();
            isCorrectAnswer = false;
        }

        if (isCorrectAnswer == false)
        {
            return;
        }

    }

    public void GenerateRandomQuestionSuffle1()
    {
        StartCoroutine(GenerateRandomQuestionSuffle());
    }

    IEnumerator GenerateRandomQuestionSuffle()
    {
        int loop = 0;
        while (loop < 1)
        {
            GenerateRandomEquation();
            //SuffleAnswerPlatform(platformLocation);
            loop++;
        }
        yield return null;
    }

    //void SuffleAnswerPlatform(Transform[] transformArray)
    //{

    //    for (int i = transformArray.Length - 1; i > 0; i--)
    //    {
    //        int j = Random.Range(0, i + 1);

    //        Transform temp = transformArray[i];
    //        transformArray[i] = transformArray[j];
    //        transformArray[j] = temp;
    //    }

    //    for (int i = 0; i < transformArray.Length; i++)
    //    {
    //        platforms[i].position = transformArray[i].position;
    //    }

    //    foreach (GameObject obj in objectToPlace)
    //    {
    //        int randomIndex = Random.Range(0, transformArray.Length);

    //        obj.transform.transform.position = transformArray[randomIndex].position;
    //        obj.transform.transform.rotation = transformArray[randomIndex].rotation;
    //        obj.transform.transform.localScale = transformArray[randomIndex].localScale;
    //        Debug.Log("looping");
    //    }
//}

    #region Math
    private void GenerateRandomEquation()
    {
        int rnd = Random.Range(1, 100);
        if (rnd <= 35)
            GenerateAddition();
        else if (rnd <= 60)
            GenerateSubtraction();
        else if (rnd <= 90)
            GenerateMultiplication();
        else
            GenerateDivision();

    }

    private void GenerateMultiplication()
    {
        operatorSign = " x ";
        numberOne = GetRandomNumber();
        numberTwo = GetRandomNumber();
        correctAnswer = numberOne * numberTwo;
        Debug.Log(numberOne + operatorSign + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    private void GenerateAddition()
    {
        operatorSign = " + ";
        numberOne = GetRandomNumber();
        numberTwo = GetRandomNumber();
        correctAnswer = numberOne + numberTwo;
        Debug.Log(numberOne + operatorSign + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    private void GenerateSubtraction()
    {
        operatorSign = " - ";
        numberOne = GetRandomNumber();
        numberTwo = GetRandomNumber();
        correctAnswer = numberOne - numberTwo;
        Debug.Log(numberOne + operatorSign + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    private void GenerateDivision()
    {
        operatorSign = " / ";
        numberOne = GetRandomNumber();
        numberTwo = GetRandomNumber();
        correctAnswer = Mathf.RoundToInt(numberOne / numberTwo);
        Debug.Log(numberOne + operatorSign + numberTwo + " = " + correctAnswer);
        GenerateDummyAnswers();
    }

    /// <summary>
    /// Gets a random number based on our difficulty
    /// </summary>
    private int GetRandomNumber()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return (Random.Range(1, 10));
            case Difficulty.MEDIUM:
                return (Random.Range(1, 20));
            case Difficulty.HARD:
                return (Random.Range(1, 100));
            default:
                return (Random.Range(1, 10));
        }
    }

    /// <summary>
    /// This will generate a set of dummy answers
    /// </summary>
    private void GenerateDummyAnswers()
    {
        //This is the incorrect answers

        for (int i = 0; i < dummyAnswers.Count; i++)
        {
            int dummy;
            do
            {
                dummy = Random.Range(correctAnswer - 10, correctAnswer + 10);
            }
            while (dummy == correctAnswer || dummyAnswers.Contains(dummy));
            dummyAnswers[i] = dummy;
            Debug.Log("Dummy answer: " + dummyAnswers[i]);
        }
    }
#endregion

}
