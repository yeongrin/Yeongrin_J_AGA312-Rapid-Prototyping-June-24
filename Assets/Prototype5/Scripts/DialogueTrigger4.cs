using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger4 : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<DialogueManager4>();
        system.StartDialogue(info);
    }
}

