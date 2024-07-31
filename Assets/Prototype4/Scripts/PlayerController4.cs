using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public float p_jumpForce = 0f;
    private bool doubleJump;
    public float y_distance;
    public static float playerHealth = 5;
    private bool isAttacked;
    public static float MaxHealth = 5;
    
    [SerializeField] Rigidbody2D p_rigid;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    SpriteRenderer spriteRenderer;
    EquationGenerator2 EG2;

    public Vector2 originalTransform;
    public Vector2 movingTransform; // if player crash the wrong answer, they move back a little
    public AnswerPlatform platform1;
    public AnswerPlatform platform2;
    public AnswerPlatform platform3;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        p_rigid = GetComponent<Rigidbody2D>();
     
        playerHealth = MaxHealth;

        originalTransform = this.transform.position;
        movingTransform = this.transform.position;
    }

    void Update()
    {
        Jump();
       
    }

    void Jump()
    {
        
        if(IsGrounded() && !Input.GetButton("Jump"))
        { 
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(IsGrounded() || doubleJump)
            {
                p_rigid.velocity = new Vector2(p_rigid.velocity.x, p_jumpForce);
                doubleJump = !doubleJump;
            }
        }

        if(Input.GetButtonUp("Jump") && p_rigid.velocity.y > y_distance)
        {
            p_rigid.velocity = new Vector2(p_rigid.velocity.x, p_rigid.velocity.y * 0.5f);
        }

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //IsCorrectAnswer is true if the player conflicts with the right platform.

        if (other.gameObject.tag == "CorrectAnswer")
        {
            EG2.isCorrectAnswer = true;
            if (EG2.isCorrectAnswer == true)
            {
                Debug.Log("correct!!");
            }

        }

        if (other.gameObject.tag == "WrongAnswer")
        {
            EG2.isCorrectAnswer = false;
            StartCoroutine(NuckBack());

           // movingTransform = new Vector2(originalTransform.x - 1f, originalTransform.y);
            this.transform.position = movingTransform;
           // originalTransform = this.transform.position;
        }

        if (other.gameObject.tag == "WrongAnswer2")
        {
            EG2.isCorrectAnswer = false;
            StartCoroutine(NuckBack());
           

            //movingTransform = new Vector2(originalTransform.x - 1f, originalTransform.y);
            this.transform.position = movingTransform;
            //originalTransform = this.transform.position;

        }
        platform1.ResetPlatform();
        platform2.ResetPlatform();
        platform3.ResetPlatform();
    }

    IEnumerator NuckBack()
    {
        //CancelInvoke("Damage");
        playerHealth -= 1;

        for (int i = 1; i < 4; i++)
        {
            
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 1; i < 4; i++)
        {
            yield return new WaitForSeconds(0.4f);

        }

    }
}
