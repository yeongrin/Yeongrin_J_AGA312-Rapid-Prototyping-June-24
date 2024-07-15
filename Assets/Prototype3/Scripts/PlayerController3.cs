using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity;
    public float jumpHeight;
    public float health;
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
