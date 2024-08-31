using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<Level1Dialogue>();
        system.StartDialogue(info);
    }
}
