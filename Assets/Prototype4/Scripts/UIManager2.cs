using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    EquationGenerator2 EG2;
    CorrectAnswerPlatform CAP;

    [Header("Text")]
    public TMP_Text[] answerText;
    public TMP_Text questionText;
    public TMP_Text questionText2;
    public TMP_Text operatorSignText;

    [Header("Health")]
    public Image[] heartImages;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        CAP = GameObject.Find("EquationGenerator").GetComponent<CorrectAnswerPlatform>();

        ReduceHeart();
    }

    void Update()
    {
        SetText();
        ReduceHeart();
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
}
