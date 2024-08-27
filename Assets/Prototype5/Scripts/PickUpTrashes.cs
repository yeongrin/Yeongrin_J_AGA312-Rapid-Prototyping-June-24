using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrashes : MonoBehaviour
{
    public int score;
    public int maxScore;
    GameManager5 GM5;
    GameManager6 GM6;
    
    void Start()
    {
        score = maxScore;
        GM5 = FindAnyObjectByType<GameManager5>();
        GM6 = FindAnyObjectByType<GameManager6>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GM5.GetScore1(score);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GM6.GetScore1(score);
            Destroy(this.gameObject);
        }
    }
}
