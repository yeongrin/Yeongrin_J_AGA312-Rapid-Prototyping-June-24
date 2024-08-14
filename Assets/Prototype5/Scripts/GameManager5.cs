using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager5 : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text movingLimit_Text;
    public TMP_Text actionLimit_Text;
    public GameObject gameEndPanel;

    PlayerController5 player5;

    void Start()
    {
        gameEndPanel.SetActive(false);
        player5 = GameObject.Find("Player").GetComponent<PlayerController5>();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        GameOver();
    }

    void SetText()
    {
        movingLimit_Text.text = player5.movingLimit.ToString();
        actionLimit_Text.text = player5.actionLimit.ToString();
    }

    void GameOver()
    {
        if(player5.movingLimit <= 0)
        {
            gameEndPanel.SetActive(true);
        }
    }
}
