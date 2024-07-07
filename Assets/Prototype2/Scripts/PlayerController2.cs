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
    public int health;

    [Header("ItemPickUp")]
    public GameObject playerEquipPoint;
    public bool dropDown = false;
    public bool isPicking = false;
    //public GameObject itemMark;
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
        //itemMark.SetActive(false);
        health = 5;

    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();

        //Dropping
        if (Input.GetKeyDown(KeyCode.Space) && isPicking)
        {
            Drop();
        }
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
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

    public void PickUp(GameObject item)
    {
        SetEquip(item, true);
        isPicking = true;
        
        if (isPicking == true)
        {
            //itemMark.SetActive(true);
        }

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

    void Drop()
    {
        GameObject item = playerEquipPoint.GetComponentInChildren<Rigidbody2D>().gameObject;
        SetEquip(item, false);
        playerEquipPoint.transform.DetachChildren();

        Rigidbody2D itemRigidbody = item.GetComponent<Rigidbody2D>();
        itemRigidbody.gravityScale = 1.5f;
        isPicking = false;

        if (isPicking == false)
        { 
           // itemMark.SetActive(false);
        }
       
    }

    void SetEquip(GameObject item, bool isEquip)
    {
        Collider2D[] itemColliders = item.GetComponents<Collider2D>();
        Rigidbody2D itemRigidbody = item.GetComponent<Rigidbody2D>();

        foreach (Collider2D itemCollider in itemColliders)
        {
            itemCollider.enabled = !isEquip;
        }
        itemRigidbody.isKinematic = isEquip;
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
           StartCoroutine(NuckBack());
        }

        if (collision.gameObject.tag == ("Enemy2"))
        {
           StartCoroutine(NuckBack());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        { 
            health -= 1; 
            
        }

        if (collision.gameObject.tag == ("Enemy2"))
        {
            health -= 2;
            
        }
    }
}
