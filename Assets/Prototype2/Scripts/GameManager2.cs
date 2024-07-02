using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager2 : MonoBehaviour
{
    public static Action _GM2;

    public TMP_Text health_Text;
    public float timer;
    public float time;

    [Header("GameOver")]
    public static int score;
    public TMP_Text score_Text;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public GameObject gameEndingPanel;

    void Awake()
    {
        _GM2 = () => { SetText(); };
    }

    void Start()
    {
        score = 0;
        timer = time;
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        SetText();

        if(score == 10)
        {
            gameEndingPanel.SetActive(true);
        }
    }

    void SetText()
    {
        score_Text.text = "PickUp : " + score.ToString();
        timerText.text = ((int)Math.Ceiling(timer)).ToString();
    }
}
