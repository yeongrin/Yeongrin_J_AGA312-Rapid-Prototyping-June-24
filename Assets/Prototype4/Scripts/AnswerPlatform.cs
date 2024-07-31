using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnswerPlatform : MonoBehaviour
{
    public static Action _AP;
    EquationGenerator2 EG2;
    
    public float speed; //speed of platform
    public float moveDuration; //How many time do platform move
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Awake()
    {
       // _AP = () => { PlatformMove(); };
    }

    void Start()
    {
        startPosition = transform.position; //Original position
        endPosition = startPosition + Vector3.left * moveDuration; //this platform move left as much as 5 does.
        PlatformMove();
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

    public void ResetPlatform()
    {
        StopCoroutine("MoveBackAndForth");
        transform.position = startPosition;
        StartCoroutine("MoveBackAndForth");
    }

}
