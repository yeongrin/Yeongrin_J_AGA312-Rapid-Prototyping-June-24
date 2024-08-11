using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<DialogueManager2>();
        system.StartDialogue(info);
    }
}