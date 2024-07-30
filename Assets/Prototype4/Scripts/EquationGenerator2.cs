using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationGenerator2 : MonoBehaviour
{

    public enum Difficulty { EASY, MEDIUM, HARD }
    public Difficulty difficulty;

    [Header("Equation")]
    public int numberOne;
    public int numberTwo;
    public int correctAnswer;  //If you choose the correct answer, move on to the next question.
    public List<int> dummyAnswers;
    public string operatorSign = "";

    [Header("SuffleAnswer")]
    public bool isCorrectAnswer; //If you collide with the right platform, this bool becomes true.
    public int[] arrays = new int[3];
    public GameObject[] platform; //This is the platform having the answers. An object with the right answer has the "CorrectAnswer" tag.

    void Start()
    {
        GenerateRandomEquation();
        GameObject player = GameObject.FindWithTag("Player");

        SuffleAnswer();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //    GenerateMultiplication();
        //if (Input.GetKeyDown(KeyCode.A))
        //    GenerateAddition();
        //if (Input.GetKeyDown(KeyCode.D))
        //    GenerateDivision();

        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateRandomEquation();
            SuffleAnswer();
        }


        if (isCorrectAnswer == true)
        {
            GenerateRandomEquation();
            SuffleAnswer();
        }

    }

    void SuffleAnswer()
    {
        //Makes the correct and incorrect answers randomly output.

        arrays[0] = dummyAnswers[0];
        arrays[1] = dummyAnswers[1];
        arrays[2] = correctAnswer;
        arrays = SuffleArray(arrays);

        for (int i = 0; i < arrays.Length; i++)
        {
            Debug.Log(arrays[i]);
        }
    }

    public T[] SuffleArray<T>(T[] array)
    {
        //Makes the correct and incorrect answers randomly output.

        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

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

    //https://coderzero.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%8A%A4%ED%81%AC%EB%A6%BD%ED%8A%B8-%EC%86%8C%EC%8A%A4-%EB%B0%B0%EC%97%B4-%EB%A6%AC%EC%8A%A4%ED%8A%B8-%EC%84%9E%EA%B8%B0Shuffle

}
