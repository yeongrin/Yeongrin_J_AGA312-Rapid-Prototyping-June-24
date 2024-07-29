using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text answerText;
    public TMP_Text answerText2;
    public TMP_Text answerText3;

    void Start()
    {
        
    }

    void Update()
    {
        SetText();
    }

    void SetText()
    {
        answerText.text = EquationGenerator2.dummyAnswers[0].ToString();
        answerText2.text = EquationGenerator2.dummyAnswers[1].ToString();
        answerText3.text = EquationGenerator2.dummyAnswers[2].ToString();
    }
}
