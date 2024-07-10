using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //call and bring Dialogue trigger

    public string name;

    [TextArea(3, 10)]
    public List<string> sentences;
}
