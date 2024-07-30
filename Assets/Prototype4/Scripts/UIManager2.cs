using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    EquationGenerator2 EG2;

    [Header("Text")]
    public TMP_Text[] answerText;
    public TMP_Text questionText;
    public TMP_Text questionText2;
    public TMP_Text operatorSignText;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
    }

    void Update()
    {
        SetText();
    }

    void SetText()
    {
        answerText[0].text = EG2.arrays[0].ToString();
        answerText[1].text = EG2.arrays[1].ToString();
        answerText[2].text = EG2.arrays[2].ToString();
        questionText.text = EG2.numberOne.ToString();
        questionText2.text = EG2.numberTwo.ToString();
        operatorSignText.text = EG2.operatorSign.ToString();
    }
}
