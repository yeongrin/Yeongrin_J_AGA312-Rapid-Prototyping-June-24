using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string[] triggerTags;
    [Space(20)]
    public UnityEvent onTriggerEnterEvent;
    public UnityEvent onTriggerStayEvent;
    public UnityEvent onTriggerExitEvent;

    public void OnTriggerEnter(Collider other) => Trigger(other, onTriggerEnterEvent);

    public void OnTriggerStay(Collider other) =>
        Trigger(other, onTriggerStayEvent);


    /*for (int i = 0; i < triggerTags.Length; i++)
    {
        if (!ObjectX.DoesTagExist(triggerTags[i]))
        {
            if (other.CompareTag(triggerTags[i]))
                onTriggerStayEvent.Invoke();

        }
    }*/

    // if (triggerTags.Length == 0)
    //return;


    public void OnTriggerExit(Collider other) =>
         Trigger(other, onTriggerExitEvent);

    /* for (int i = 0; i < triggerTags.Length; i++)
     {
         if (!ObjectX.DoesTagExist(triggerTags[i]))
         {
             if (other.CompareTag(triggerTags[i]))
                 onTriggerExitEvent.Invoke();

         }
     }*/
    //if (triggerTags.Length == 0)
    //  return;
    private void Trigger(Collider _other, UnityEvent _event)
    {
        for (int i = 0; i < triggerTags.Length; i++)
        {
            if (ObjectX.DoesTagExist(triggerTags[i]))
            {
                if (_other.CompareTag(triggerTags[i]))
                    _event.Invoke();

            }
        }
    }
}
