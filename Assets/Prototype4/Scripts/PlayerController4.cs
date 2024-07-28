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

    void Start()
    {
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
            Debug.Log("2435");

           
                if(_hit.transform.CompareTag("Ground"))
                {
                    p_jumpCount = 0;
                }
            
        }
    }
}
