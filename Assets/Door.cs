using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorDefense;

    void Start()
    {
        doorDefense = 10;
    }

   
    void Update()
    {
        
    }

    public void DoorTrigger()
    {
           Debug.Log("jit");
        doorDefense -= 1;
        
    }
}
