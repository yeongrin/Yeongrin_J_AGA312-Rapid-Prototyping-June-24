using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class GameManager5 : MonoBehaviour
{
    public static Action GM5;
    public static Action GM5v2;

    [Header("Text")]
    public TMP_Text movingLimit_Text;
    public TMP_Text actionLimit_Text;
    public GameObject gameOverPanel;
    public GameObject gameEndPanel;

    public int cleanliness;
    public int monsterCount;
    public TMP_Text cleanliness_Text;

    PlayerController5 player5;
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
        player5 = GameObject.Find("Player").GetComponent<PlayerController5>();
        monsterCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
        movingLimit_Text.text = player5.movingLimit.ToString();
        actionLimit_Text.text = player5.actionLimit.ToString();
        cleanliness_Text.text = cleanliness.ToString();
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
        if(player5.movingLimit < 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (player5.actionLimit < 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void GameEnding()
    {
        if(cleanliness == 100)
        {
            gameEndPanel.SetActive(true);
        }
    }
}
