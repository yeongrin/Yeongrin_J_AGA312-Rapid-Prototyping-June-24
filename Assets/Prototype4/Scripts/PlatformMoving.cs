using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using TMPro;
using UnityEngine.UI;

public class PlatformMoving : MonoBehaviour
{
    EquationGenerator2 EG2;
    CorrectAnswerPlatform CAP;
    public Vector3[] objectToPlace;
    public float speed; //speed of platform
    public float moveDuration; //How many time do platform move

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        CAP = FindObjectOfType<CorrectAnswerPlatform>();
        objectToPlace = CAP.GetObjectPositions();
   

        //startPosition = transform.position; //Original position
        //endPosition = startPosition + Vector3.left * moveDuration; //this platform move left as much as 5 does.
        PlatformMove(); //Swap and moving platform
    }

    void PlatformMove()
    {
        StartCoroutine("MoveBackAndForth");
    }

    IEnumerator MoveBackAndForth()
    {
        SwapPositions(); //Swap position

        float elapedTime = 0f;
        while (elapedTime < moveDuration)
        {
            //transform.position = Vector3.Lerp(startPosition, endPosition, elapedTime / moveDuration);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            elapedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    public void ResetPlatform()
    {
        StopCoroutine("MoveBackAndForth");
        //transform.position = startPosition;
        StartCoroutine("MoveBackAndForth");
        
    }

    public void SwapPositions()
    {
       //this is working

        // Get all platforms that are colliding
        Transform[] platforms = CAP.platforms;
        Vector3[] positions = new Vector3[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            positions[i] = platforms[i].position;
        }

        // Shuffle positions and apply them
        Shuffle(positions);

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].position = positions[i];
        }
    }

    private void Shuffle(Vector3[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            Vector3 temp = array[i];
            array[i] = array[r];
            array[r] = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ResetPlatform();
            EG2.GenerateRandomQuestionSuffle1();
        }
    }

}
