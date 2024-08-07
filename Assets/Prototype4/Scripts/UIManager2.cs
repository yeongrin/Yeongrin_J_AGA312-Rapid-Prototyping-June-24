using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    EquationGenerator2 EG2;
    CorrectAnswerPlatform CAP;
    private bool paused;

    [Header("Text")]
    public TMP_Text[] answerText;
    public TMP_Text questionText;
    public TMP_Text questionText2;
    public TMP_Text operatorSignText;

    [Header("Health")]
    public Image[] heartImages;

    [Header("Slider")]
    public Slider slider;
    public float maxTime;
    public float elapsedTime = 0f;
    public GameObject gameOverPanel;
    public GameObject gameEndingPanel;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        CAP = GameObject.Find("EquationGenerator").GetComponent<CorrectAnswerPlatform>();

        paused = false;
        gameEndingPanel.SetActive(paused);
        Time.timeScale = 1;

        ReduceHeart();

        if (slider != null)
        {
            slider.value = 0f;
        }
    }

    void Update()
    {
        SetText();
        ReduceHeart();

        if(slider != null)
        {
            elapsedTime += Time.deltaTime;

            float normalizedTime = Mathf.Clamp(elapsedTime / maxTime, 0f, 1f);
            slider.value = normalizedTime;
        }
        if (PlayerController4.playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);

        }
        if (elapsedTime >= maxTime)
        {
            GameEnding();
        }
    }

    void SetText()
    {
        answerText[0].text = CAP.inCorrect.ToString();
        answerText[1].text = CAP.inCorrect2.ToString();
        answerText[2].text = CAP.correct.ToString();
        questionText.text = EG2.numberOne.ToString();
        questionText2.text = EG2.numberTwo.ToString();
        operatorSignText.text = EG2.operatorSign.ToString();
    }

    void ReduceHeart()
    { 
        for (int i = 0; i < heartImages.Length; i++)
        {
            if(i < PlayerController4.playerHealth)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }

    public void GameEnding()
    {
        
            paused = !paused;
            gameEndingPanel.SetActive(paused);
            if (paused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            Time.timeScale = paused ? 0 : 1;
        

    }
}
