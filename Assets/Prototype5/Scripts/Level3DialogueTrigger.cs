using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void DLTrigger()
    {
        var system = FindObjectOfType<Level3Dialogue>();
        system.StartDialogue(info);
    }


}
