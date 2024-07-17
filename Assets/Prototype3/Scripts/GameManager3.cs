using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager3 : MonoBehaviour
{
    public static Action GM;

    [Header("State")]
    public TMP_Text doorDefense_Text; 
    public TMP_Text enemy_Text; 
    public TMP_Text force_Text;

    [Header("State")]
    public static int enemyScore;
    public static int forceScore;

    Door door;

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
       
    }

   
    void Update()
    {
        SetText();
    }

    public void SetText()
    {
        doorDefense_Text.text = "DoorDefense : " + door.doorDefense.ToString();
        enemy_Text.text = "Enemy:" + enemyScore.ToString();
        force_Text.text = "Force:" + forceScore.ToString();
    }
}
