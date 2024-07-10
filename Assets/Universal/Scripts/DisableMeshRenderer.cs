using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRenderer : MonoBehaviour
{
    private void Awake()
    {
        if(GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
