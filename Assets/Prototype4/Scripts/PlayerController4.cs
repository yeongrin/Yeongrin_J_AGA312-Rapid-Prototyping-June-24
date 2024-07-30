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
    public static float playerHealth = 5;
    public static float MaxHealth = 5;
    float p_distance = 0f;

    SpriteRenderer spriteRenderer;

    [SerializeField] LayerMask p_layerMask = 0;

    EquationGenerator2 EG2;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        EG2 = GameObject.Find("EquationGenerator").GetComponent<EquationGenerator2>();
        p_rigid = GetComponent<Rigidbody2D>();
        p_distance = GetComponent<BoxCollider2D>().bounds.extents.y + bounce;

        playerHealth = MaxHealth;
    }

    void Update()
    {
        Jump();
        CheckGround();

        if(Input.GetKeyDown(KeyCode.P))
        {
            Punishment();
        }
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
            StartCoroutine(NuckBack());
            Punishment();
        }
    }

    void Punishment()
    {
        playerHealth -= 1;
     
    }

    IEnumerator NuckBack()
    {
        //CancelInvoke("Damage");

        for (int i = 1; i < 4; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }


    }
}
