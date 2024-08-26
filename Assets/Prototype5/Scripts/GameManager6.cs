using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class GameManager6 : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text movingLimit_Text;
    public TMP_Text actionLimit_Text;
    public GameObject gameOverPanel;
    public GameObject gameEndPanel;

    public int cleanliness;
    public int boxCount;
    //public TMP_Text cleanliness_Text;
    public TMP_Text boxCount_Text;

    PlayerController6 player6;
    TrashEnemies trashEnemies;
    PickUpTrashes pickUp;

    private void Awake()
    {
        //GM5 = () => { SetText(); GetScore1(PickUpTrashes _put); };
        //GM5v2 = () => { SetText(); GetScore2(); };
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        gameEndPanel.SetActive(false);
        player6 = GameObject.Find("Player").GetComponent<PlayerController6>();
        boxCount = GameObject.FindGameObjectsWithTag("Target").Length;
        trashEnemies = gameObject.GetComponent<TrashEnemies>();
        pickUp = gameObject.GetComponent<PickUpTrashes>();

        cleanliness = 0;

        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        GameOver();
        GameEnding();
    }

    void SetText()
    {
        movingLimit_Text.text = player6.movingLimit.ToString();
        actionLimit_Text.text = player6.actionLimit.ToString();
        boxCount_Text.text = boxCount.ToString();
        //cleanliness_Text.text = cleanliness.ToString();
    }

    public void GetScore1(int _score)
    {
        cleanliness += _score;
    }

    public void GetScore2(int _score)
    {
        cleanliness += _score;
    }

    void GameOver()
    {
        if (player6.movingLimit < 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (player6.actionLimit < 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void GameEnding()
    {
        if (boxCount <= 0)
        {
            gameEndPanel.SetActive(true);
        }
    }
}

