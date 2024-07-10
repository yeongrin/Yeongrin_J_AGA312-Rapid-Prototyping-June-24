using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager2 : MonoBehaviour
{
    public static Action _GM2;
    public float timer;
    public float time;

    [Header ("Heart")]
    public TMP_Text health_Text;
    public Image[] heartUI;
    public Sprite heartSpirites;

    [Header("GameOver")]
    public static int score;
    public TMP_Text score_Text;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public GameObject gameEndingPanel;

    GameObject player;
    PlayerController2 _PC2;

    void Awake()
    {
        _GM2 = () => { SetText(); };
        player = GameObject.FindGameObjectWithTag("Player");
        _PC2 = player.GetComponent<PlayerController2>();

    }

    void Start()
    {
        score = 5;
        SetText();
        timer = time;
    }


    // Update is called once per frame
    void Update()
    {
        SetText();
        StartCoroutine(TimerAndLives());

        if (score <= 0)
        {
            gameEndingPanel.SetActive(true);
                StopCoroutine(TimerAndLives());
        }
       
        if(timer <= 0)
        {
            gameOverPanel.SetActive(true);
            StopCoroutine(TimerAndLives());
           
        }
      
        if(_PC2.health <= 0)
        {
            gameOverPanel.SetActive(true);
            StopCoroutine(TimerAndLives());
         
        }
      
    }

    IEnumerator TimerAndLives()
    {
        timer -= Time.deltaTime;
        //heartUI.sprite = heartSpirites[_PC2.health];

        for (int i = 0; i < _PC2.health; i++)
        {
            if( i < _PC2.health)
            {
                heartUI[i].enabled = true;
            }
            else
            {
                heartUI[i].enabled = false;
            }
        }
        SetText();
        yield break;
    }

    public void SetText()
    {
        score_Text.text = "PickUp : " + score.ToString();
        health_Text.text = "Lives : " + _PC2.health.ToString();
        timerText.text = ((int)Math.Ceiling(timer)).ToString();
    }
}
