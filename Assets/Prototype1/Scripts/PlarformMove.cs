using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlatformType
{   
    None,
    Move1,
}

public class PlarformMove : MonoBehaviour
{
    public PlatformType type;

    public float startPos;
    public float tweenTime;
    public Ease tweenEase ;
    public float changeTime;
    public float time = 0f;
    public float time2 = 0f;

    public float delayTime;

    private void Awake()
    {
        changeTime = 5f;
        
    }
    void Start()
    {
        startPos = transform.position.y;   
    }

    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

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
        }

    }

    void MoveFlatform1()
    {
        
        transform.DOMoveY(startPos + 10, tweenTime).SetEase(tweenEase);

    }

    void MoveFlatform2()
    {
        //int rnd = Random.Range(0, 5);
        if (time2 > 5)
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
