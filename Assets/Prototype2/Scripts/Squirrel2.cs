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

    public GameObject heart;

    Animator ani;

    void Start()
    {
        currentPositionX = transform.position.x;
        currentPositionY = transform.position.y;
        ani = GetComponent<Animator>();

        heart.gameObject.SetActive(false);
    }

    
    void Update()
    {
        heart.transform.position = transform.position + new Vector3(0, 1f, 0);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == ("PowerUp"))
        {
            heart.gameObject.SetActive(true);
            StartCoroutine(HeartInspection());
        }
    }

    IEnumerator HeartInspection()
    {
        yield return new WaitForSeconds(0.5f);
        heart.gameObject.SetActive(false);
        
    }
}
