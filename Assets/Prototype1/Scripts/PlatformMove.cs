using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlatformType
{   
    None,
    Move1,
    Move2,
    Move3
}

public class PlatformMove : MonoBehaviour
{
    public PlatformType type;

    public float startPos;
    public float startPos2;
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

            case PlatformType.Move1:
                {

                    if (time2 > changeTime)
                    {
                        time2 = 0;
                        //changeTime = Random.Range(4, 10);
                        MoveFlatform2();
                    }
                }
                break;

            case PlatformType.Move2:
                {

                    if (time2 > changeTime)
                    {
                        time2 = 0;
                        //changeTime = Random.Range(4, 10);
                        MoveFlatform3();
                    }
                }
                break;

            case PlatformType.Move3:
                if (time2 > changeTime)
                {
                    time2 = 0;
                    //changeTime = Random.Range(4, 10);
                    MoveFlatform4();
                }
                break;
        }
    }

    public void MoveFlatform1()
    {
        
        transform.DOMoveY(startPos + 10, tweenTime).SetEase(tweenEase);

    }

    public void MoveFlatform2()
    {
        //int rnd = Random.Range(0, 5);
        if (time2 > changeTime)
        {
            transform.DOMoveY(startPos + 10, tweenTime).SetEase(tweenEase);
            time2 = 0;

            if (time2 > changeTime)
            {
                time2 = 0;
                transform.DOMoveY(startPos - 10, tweenTime).SetEase(tweenEase);
                
            }
        }
    }

    public void MoveFlatform3()
    {
        if (time3 > changeTime)
        {
            transform.DOMoveX(startPos2 + 10, tweenTime).SetEase(tweenEase);
            time3 = 0;

            if (time3 > resetTime)
            {
                time3 = 0;
                transform.DOMoveX(startPos2 - 10, tweenTime).SetEase(tweenEase);
                Debug.Log("moving....");

            }
        }

        //코루틴을 사용해서 값을 4초나 5초 간격으로 되돌리고 해야 할 것 같음.
    }

    public void MoveFlatform4()
    {
        if (time3 > changeTime)
        {
            transform.DOMoveX(startPos2 - 10, tweenTime).SetEase(tweenEase);
            time3 = 0;

            if (time3 > changeTime)
            {
                time3 = 0;
                transform.DOMoveX(startPos2 + 10, tweenTime).SetEase(tweenEase);
                Debug.Log("moving....");

            }
        }
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
