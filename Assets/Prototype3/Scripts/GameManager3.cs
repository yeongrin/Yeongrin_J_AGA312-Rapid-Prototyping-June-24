using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager3 : MonoBehaviour
{
    public static Action GM;

    [Header("Text")]
    public TMP_Text doorDefense_Text; 
    public TMP_Text enemy_Text; 
    public TMP_Text force_Text;
    public GameObject GameEndPanel;

    [Header("State")]
    public static int enemyScore;
    public static int forceScore;

    Door door;

    [Header ("Timer")]
    public Timer timer;
    public TMP_Text timerText;

    private void Awake()
    {
        GM = () => { SetText(); };

        door = GameObject.Find("Door").GetComponent<Door>();
    }

    void Start()
    {
        enemyScore = 0;
        forceScore = 0;
        SetText();
        timer.StartTimer(60, TimerDirection.CountDown);

    }

   
    void Update()
    {
        SetText();
        timer.StartTimer(60, 0, true, TimerDirection.CountDown);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timer.ToggleTimerPause();
        }
        if (timer.TimeExpired())
        {
            timerText.text = "0";
            timer.ToggleTimerPause();
            GameEndPanel.SetActive(true);
        }
    }

    public void SetText()
    {
        doorDefense_Text.text = "DoorDefense : " + door.doorDefense.ToString();
        enemy_Text.text = "Enemy:" + enemyScore.ToString();
        force_Text.text = "Force:" + forceScore.ToString();
        timerText.text = timer.GetTime().ToString();
    }
}
