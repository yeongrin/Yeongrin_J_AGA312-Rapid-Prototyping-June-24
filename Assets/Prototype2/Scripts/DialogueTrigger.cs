using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.StartDialogue(info);
    }
}

