using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlatformMoving : MonoBehaviour
{
    EquationGenerator2 EG2;
    CorrectAnswerPlatform CAP;
    public Vector3[] objectToPlace;
    public float speed; //speed of platform
    public float moveDuration; //How many time do platform move

    Vector3 startPosition;
    Vector3 endPosition;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        CAP = FindObjectOfType<CorrectAnswerPlatform>();
        objectToPlace = CAP.GetObjectPositions();
        startPosition = transform.position; //Original position
        SetPositions();
        PlatformMove(); //Swap and moving platform
    }

    void SetPositions()
    {
        endPosition = startPosition + Vector3.left * moveDuration; //this platform move left as much as 5 does.
    }

    void PlatformMove()
    {
        StartCoroutine("MoveBackAndForth");
    }

    IEnumerator MoveBackAndForth()
    {
        float elapedTime = 0f;
        while (elapedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapedTime / moveDuration);
            elapedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    public void ResetPlatform(Vector3 _startPos)
    {
        StopCoroutine("MoveBackAndForth");
        startPosition = _startPos;
        transform.position = startPosition;
        SetPositions();
        StartCoroutine("MoveBackAndForth");
        
    }

}
