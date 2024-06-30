using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel2 : MonoBehaviour
{
    public float rightMax;
    public float leftMax;
    public float currentPositionX;
    public float currentPositionY;
    public float directionSpeed;

    Animator ani;

    void Start()
    {
        currentPositionX = transform.position.x;
        currentPositionY = transform.position.y;
        ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        currentPositionX += Time.deltaTime * directionSpeed;
        if(currentPositionX >= rightMax)
        {
            directionSpeed *= -1;
            currentPositionX = rightMax;
            ani.SetTrigger("Left");
            
        }
        else if (currentPositionX <= leftMax)
        {
            directionSpeed *= -1;
            currentPositionX = leftMax;
            ani.SetTrigger("Right");
        }

        transform.position = new Vector3(currentPositionX, currentPositionY, 0);
    }
}
