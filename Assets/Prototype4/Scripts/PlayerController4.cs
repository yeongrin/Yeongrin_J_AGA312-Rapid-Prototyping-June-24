using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController4 : GameBehaviour
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
    EnemyFollowingThePlayer _enemy;

    public Vector2 originalTransform;
    public Vector2 movingTransform; // if player crash the wrong answer, they move back a little
    public PlatformMoving platform1;
    public PlatformMoving platform2;
    public PlatformMoving platform3;
    public Vector3[] platformStartPositions;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        platformStartPositions[0] = platform1.transform.position;
        platformStartPositions[1] = platform2.transform.position;
        platformStartPositions[2] = platform3.transform.position;

        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        _enemy = GameObject.Find("Atoma").GetComponent<EnemyFollowingThePlayer>();
        p_rigid = GetComponent<Rigidbody2D>();
     
        playerHealth = MaxHealth;

        originalTransform = this.transform.position;
        movingTransform = this.transform.position;
        
    }

    void Update()
    {
        Jump();
       
        if(playerHealth == 4)
        {

        }

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
                
            }

        }

        if (other.gameObject.tag == "WrongAnswer")
        {
            _EFFECT.TweenVignetteInOut(0.5f, 0.5f);
            EG2.isCorrectAnswer = false;
            _enemy.MoveTowardsPlayers();
            StartCoroutine(NuckBack());

            this.transform.position = movingTransform;

        }

        if (other.gameObject.tag == "WrongAnswer2")
        {
            _EFFECT.TweenVignetteInOut(0.5f, 0.5f);
            EG2.isCorrectAnswer = false;
            _enemy.MoveTowardsPlayers();
            StartCoroutine(NuckBack());
           

            //movingTransform = new Vector2(originalTransform.x - 1f, originalTransform.y);
            this.transform.position = movingTransform;
            //originalTransform = this.transform.position;

        }
        Shuffle(platformStartPositions);
        platform1.ResetPlatform(platformStartPositions[0]);
        platform2.ResetPlatform(platformStartPositions[1]);
        platform3.ResetPlatform(platformStartPositions[2]);
        EG2.GenerateRandomQuestionSuffle1();
    }

    private void Shuffle(Vector3[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            Vector3 temp = array[i];
            array[i] = array[r];
            array[r] = temp;
        }
    }

    IEnumerator NuckBack()
    {
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
