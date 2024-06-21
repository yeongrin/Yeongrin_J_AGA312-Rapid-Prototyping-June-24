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

    [Header("EndPos")]
    public float moving = 0f;

    [Header("Time")]
    public float tweenTime;
    public Ease tweenEase ;
    public float changeTime;
    public float resetTime;
    public float time = 0f;
    public float time2 = 0f;
    public float time3 = 0f;

    public float delayTime;

    private void Awake()
    {
        changeTime = 5f;
        
    }
    void Start()
    {
        startPos = transform.position.y;
        startPos2 = transform.position.x;
    }

    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        time3 += Time.deltaTime;

        switch (type)
        {
            case PlatformType.None:
                {

                    if (time > 2)
                    {
                        time = 0;
                        //changeTime = Random.Range(4, 10);
                        MoveFlatform1();
                    }
                }
                break;

            case PlatformType.Move2:
                {

                    if (time2 > changeTime)
                    {
                        time2 = 0;
                        //changeTime = Random.Range(4, 10);
                        StartCoroutine(MoveFlatform2());
                    }
                }
                break;

            case PlatformType.Move3:
                {

                    if (time2 > changeTime)
                    {
                        time2 = 0;
                        //changeTime = Random.Range(4, 10);
                        StartCoroutine(MoveFlatform3());
                        
                    }
                }
                break;

            case PlatformType.Move4:
                if (time2 > changeTime)
                {
                    time2 = 0;
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
    {
       
            transform.DOMoveY(startPos - moving, tweenTime).SetEase(tweenEase);
            time2 = 0;
            

            yield return new WaitForSeconds(10f);
            {
                time2 = 0;
                transform.DOMoveY(startPos + moving, tweenTime).SetEase(tweenEase);
                
            }
        
        yield return new WaitForSeconds(5f);
    }

    IEnumerator MoveFlatform3()
    {
      
            transform.DOMoveX(startPos2 + moving, tweenTime).SetEase(tweenEase);
            time3 = 0;

            yield return new WaitForSeconds(8f);
            {
                time3 = 0;
                transform.DOMoveX(startPos2 - moving, tweenTime).SetEase(tweenEase);
               

            }
        
        yield return new WaitForSeconds(5f);
    }

    IEnumerator MoveFlatform4()
    {
      
            transform.DOMoveX(startPos2 - moving, tweenTime).SetEase(tweenEase);
            time3 = 0;

            yield return new WaitForSeconds(8f);
            {
                time3 = 0;
                transform.DOMoveX(startPos2 + moving, tweenTime).SetEase(tweenEase);
                Debug.Log("moving....");

            }
        
        yield return new WaitForSeconds(5f);
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
