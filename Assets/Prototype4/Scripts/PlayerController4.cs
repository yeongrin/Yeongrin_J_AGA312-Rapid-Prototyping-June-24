using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    [SerializeField] float p_jumpForce = 0f;
    [SerializeField] float p_maxJumpCount = 0f;
    public int p_jumpCount = 0;

    Rigidbody2D p_rigid = null;

    public float bounce;
    public float y_distance;
    float p_distance = 0f;
    [SerializeField] LayerMask p_layerMask = 0;

    EquationGenerator2 EG2;

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        p_rigid = GetComponent<Rigidbody2D>();
        p_distance = GetComponent<BoxCollider2D>().bounds.extents.y + bounce;
    }

    void Update()
    {
        Jump();
        CheckGround();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(p_jumpCount < p_maxJumpCount)
            {
                p_jumpCount++;
                p_rigid.velocity = Vector2.up * p_jumpForce;
            }
        }

    }

    void CheckGround()
    {
        if(p_rigid.velocity.y < y_distance)
        {
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, p_distance, p_layerMask);


            if (_hit.transform.CompareTag("Ground"))
            {
                Debug.Log("2435");
                p_jumpCount = 0;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //IsCorrectAnswer is true if the player conflicts with the right platform.

        if (collider.tag == "CorrectAnswer")
        {
            EG2.isCorrectAnswer = true;
            if (EG2.isCorrectAnswer == true)
            {
                Debug.Log("correct!!");
            }

        }

        if (collider.tag == "WrongAnswer")
        {
            EG2.isCorrectAnswer = false;
        }
    }
}
