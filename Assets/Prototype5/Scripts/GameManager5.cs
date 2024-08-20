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
    public GameObject gameOverPanel;
    public GameObject gameEndPanel;

    public int monsterCount;
    public TMP_Text monsterCountText;

    PlayerController5 player5;

    void Start()
    {
        gameOverPanel.SetActive(false);
        gameEndPanel.SetActive(true);
        player5 = GameObject.Find("Player").GetComponent<PlayerController5>();

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
        monsterCountText.text = monsterCount.ToString();
    }

    void GameOver()
    {
        if(player5.movingLimit <= 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (player5.actionLimit <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void GameEnding()
    {
        if(monsterCount <= 0)
        {
            gameEndPanel.SetActive(true);
        }
    }
}
