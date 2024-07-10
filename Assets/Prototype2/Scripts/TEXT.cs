using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEXT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Test()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hit");
        }

    }
}
