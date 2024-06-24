using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlatformType
{   
    None,
    Move2,
    Move3,
    Move4
}

public class PlatformMove : MonoBehaviour
{
    public PlatformType type;

    [Header ("StartPos")]
    public float startPos;
    public float startPos2;

    [Header("StartPos")]
    public float endPos;
    public float endPos2;

    [Header("timebool")]
    public int moving;

    [Header("Time")]
    public float tweenTime;
    public Ease tweenEase ;
    public float changeTime;

    public float time = 0f;
    public float time2 = 0f;
    public float time3 = 0f;
    public float time4 = 0f;

    public float end3 = 0f;

    public float delayTime;

    private void Awake()
    {
        //changeTime = 5f;
        
    }
    void Start()
    {
        startPos = transform.position.y;
        startPos2 = transform.position.x;
    }

    void Update()
    {
       
        switch (type)
        {
            case PlatformType.None: //Move up
                { 
                    time += Time.deltaTime;

                    if (time > changeTime)
                    {
                        time = 0;
                        //changeTime = Random.Range(4, 10);
                        MoveFlatform1();
                    }
                }
                break;

            case PlatformType.Move2: //Move up and down
                {
                    time2 += Time.deltaTime;

                    if (time2 > changeTime)
                    {

                        StartCoroutine(MoveFlatform2());

                    }
                    break;
                }
            case PlatformType.Move3://Move horizontal
                {
                    time3 += Time.deltaTime;

                    if (time3 > changeTime)
                    {
                        //changeTime = Random.Range(4, 10);
                        StartCoroutine(MoveFlatform3());

                    }
                
                }
                break;

            case PlatformType.Move4: //Move down and up
                if (time4 > changeTime)
                {
                    time4 = 0;
                    //changeTime = Random.Range(4, 10);
                    StartCoroutine(MoveFlatform2());
                }
                break;
        }
        
    }

    public void MoveFlatform1()
    {
        
        transform.DOMoveY(startPos + moving, tweenTime).SetEase(tweenEase);

    }

    IEnumerator MoveFlatform2()
    { //changeTime = Random.Range(4, 10);

       transform.DOMoveY(startPos + moving, tweenTime).SetEase(tweenEase);
       time2 = 0;
       endPos = startPos + moving;

        yield return new WaitForSeconds(5f);
        {
            transform.DOMoveY(endPos - moving, tweenTime).SetEase(tweenEase);
            time2 = 0;
            startPos = transform.position.y;
        }

        //yield return new WaitForSeconds(5f);

    }

    IEnumerator MoveFlatform3()
    {

        transform.DOMoveX(startPos2 + moving, tweenTime).SetEase(tweenEase);
        time3 = 0;
        endPos2 = startPos2 + moving;

        yield return new WaitForSeconds(7f);
        {
            transform.DOMoveX(endPos2 - moving, tweenTime).SetEase(tweenEase);
            time3 = 0;
            startPos2 = transform.position.x - moving;

        }

        //yield return new WaitForSeconds(5f);
    }

    IEnumerator MoveFlatform4()
    {

        transform.DOMoveX(startPos - moving, tweenTime).SetEase(tweenEase);
        time4 = 0;
        endPos = startPos + moving;

        yield return new WaitForSeconds(5f);
        {
            transform.DOMoveX(startPos + moving, tweenTime).SetEase(tweenEase);
            time4 = 0;


        }

        //yield return new WaitForSeconds(5f);
    }

    /* void MoveFlatform2()
     {
         //int rnd = Random.Range(0, 5);
         if (rnd < 3)
         {
             transform.DOMoveY(startPos + 10, tweenTime).SetEase(tweenEase);

             if (time > changeTime)
             {
                 time = 0;
                 if (rnd >= 3)
                 {
                     transform.DOMoveY(startPos - 10, tweenTime).SetEase(tweenEase);
                 }
             }
         }
     }*/
}
