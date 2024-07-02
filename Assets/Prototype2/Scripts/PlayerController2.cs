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
    public GameObject itemMark;
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
        itemMark.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.X) && isPicking)
        {
            Drop();
            Debug.Log("drop");
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

    public void PickUp(GameObject item)
    {
        SetEquip(item, true);
        isPicking = true;
        Debug.Log("pickup");

        if (isPicking == true)
        {
            itemMark.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Damage(); 
        }
    }

    void Damage()
    {
        health -= 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            StartCoroutine(NuckBack());
        }
    }

    IEnumerator NuckBack()
    {
        CancelInvoke("Damage");
        Debug.Log("256657");
        yield return new WaitForSeconds(5);

    }

    void Drop()
    {
        GameObject item = playerEquipPoint.GetComponentInChildren<Rigidbody2D>().gameObject;
        SetEquip(item, false);

        playerEquipPoint.transform.DetachChildren();
        isPicking = false;

        if (isPicking == false)
        { 
            itemMark.SetActive(false);
        }
       
    }

    void SetEquip(GameObject item, bool isEquip)
    {
        Collider2D[] itemColliders = item.GetComponents<Collider2D>();
        Rigidbody2D itemRigidbody = item.GetComponent<Rigidbody2D>();

        foreach(Collider2D itemCollider in itemColliders)
        {
            itemCollider.enabled = !isEquip;
        }
        itemRigidbody.isKinematic = isEquip;
     
    }
}
