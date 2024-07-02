using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static Action GM;
    PlayerController PM;//Set the text

    [Header("State")]
    public TMP_Text damage_Text; //Player Attack=Power2
    public TMP_Text armor_Text; //Player Defense=Power
    public TMP_Text health_Text;

    [Header("Platform")]
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject obstacle;

    [Header("GameOver")]
    public static int score;
    public TMP_Text score_Text;
    public GameObject canvas;
    public GameObject gameOverPanel;
    public GameObject gameEndingPanel;
    

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
        SetText();

        if (score >= 5)
        {
            platform1.SetActive(true);
    

            if (score >= 10)
            {
                platform2.SetActive(true);


                if (score >= 20)
                {
                    platform3.SetActive(true);

                   
                        if (score >= 25)
                        {

                            Destroy(obstacle.gameObject);

                        if (score >= 50)
                        {
                            gameEndingPanel.SetActive(true);
                        }


                        }

                    
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
