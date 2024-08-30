using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnWarm2 : MonoBehaviour
{
    public Rigidbody rigid;
    Vector2 moveDirection = new Vector2(1f, 0.25f);
    int moveSpeed = 1;
    
    void Start()
    {
        rigid.velocity = moveDirection * moveSpeed;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
