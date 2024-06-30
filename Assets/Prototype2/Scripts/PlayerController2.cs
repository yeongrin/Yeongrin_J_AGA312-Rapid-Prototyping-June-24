using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Header("PlayerAbility")]
    public float speed;
    public int jumpHeight;
    private bool isMoving;
    private bool jump;
  
    public bool dropDown = false;
    private double Timer = 0;

    Vector2 movement = new Vector2();
    Rigidbody2D rgb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rgb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
            Jump();
        
      
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            isMoving = true;
            animator.SetBool("isMoving", true);
            spriteRenderer.flipX = false;

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            isMoving = true;
            animator.SetBool("isMoving", true);
            spriteRenderer.flipX = true;
        }
        else
            isMoving = false;

        transform.position += moveVelocity * speed * Time.deltaTime;

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jump = true;
            animator.SetTrigger("doJumping");
            rgb.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpHeight);
            rgb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            jump = false;
        }

        if (!jump)
            return;
      
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Pick Up
        if (Input.GetKeyDown(KeyCode.X) && col.gameObject.CompareTag("PowerUp"))
        {
            dropDown = false;

            if (!dropDown)
            {
                Destroy(col.gameObject);
                dropDown = true;

                if (dropDown == true)
                {
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        Debug.Log("lop");
                    }
                   
                }

            }
           
        }

        //Drop down
  
    }
}
