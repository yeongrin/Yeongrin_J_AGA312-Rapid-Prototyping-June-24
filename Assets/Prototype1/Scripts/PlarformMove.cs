using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlarformMove : MonoBehaviour
{
    public float startPos;
    public float tweenTime;
    public Ease tweenEase ;
    public float changeTime;
    float time = 0f;

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
        if(time > changeTime)
        {
            time = 0;
            //changeTime = Random.Range(4, 10);
            MoveFlatform();
        }
    }

    void MoveFlatform()
    {
        int rnd = Random.Range(0, 10);
        if(rnd < 5)
        {
        transform.DOMoveY(startPos + 10, tweenTime).SetEase(tweenEase);

        }
    }
}
