using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static Action GM;
    public int score;
    public TMP_Text score_Text;
    public GameObject canvas;

    [Header("Platform")]
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;

    private void Awake()
    {
        GM = () => { GetScore(); SetText(); };
    }

    void Start()
    {
        score = 0;
        SetText();
        GetScore();
    }

    void Update()
    {
        
        
    }

    void GetScore()
    {
        score += 1;

        if(score == 2)
        {
            platform1.SetActive(true);
            platform2.SetActive(true);
        }
    }

    void SetText()
    {
        score_Text.text = "Score : " + score.ToString();
    }
}
