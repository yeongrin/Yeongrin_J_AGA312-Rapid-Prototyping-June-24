using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<Level2Dialogue>();
        system.StartDialogue(info);
    }
}
