using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<DialogueManager5>();
        system.StartDialogue(info);
    }
}
