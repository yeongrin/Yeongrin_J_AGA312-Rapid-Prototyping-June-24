using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static Action GM;
    public static int score;
    public TMP_Text score_Text;
    public GameObject canvas;
    public GameObject gameOverPanel;

    [Header("State")]
    public TMP_Text damage_Text; //Player Attack=Power2
    public TMP_Text armor_Text; //Player Defense=Power
    public TMP_Text health_Text;

    [Header("Platform")]
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform5;
    public GameObject platform6;

    PlayerController PM;//Set the text
    

   private void Awake()
    {
        GM = () => { SetText(); };

        PM = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    void Start()
    {
        score = 0;
        SetText();
        
    }

    void Update()
    {

        if (score >= 5)
        {
            platform1.SetActive(true);
            platform2.SetActive(true);

            if (score >= 15)
            {
                platform3.SetActive(true);
                platform4.SetActive(true);

                if (score >= 30)
                {
                    platform5.SetActive(true);
                    platform6.SetActive(true);
                }
            }

        }

        if(PM.playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
        }

    }


    public void SetText()
    {
        score_Text.text = "Score : " + score.ToString();

        damage_Text.text = "Power:" + PM.playerDamage.ToString();
        armor_Text.text = "Armor:" + PM.playerArmor.ToString();
        health_Text.text = "Health:" + PM.playerHealth.ToString();
    }
}
