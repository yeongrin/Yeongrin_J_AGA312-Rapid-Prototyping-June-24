using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController5 : MonoBehaviour
{
    [SerializeField] private bool isRepeatedMovement = false;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;

    Animator ani;

    [Header("Moving account")]
    private bool isMoving = false;
    Rigidbody2D rigid;
    public int movingLimit ;
    public int actionLimit ;

    private Tile currentTile;

    float X;
    float Y;

    [Header("Attack")]
    private float curTime;
    public float coolTime = 0.5f;
    public Transform posLeft;
    public Transform posRight;
    public Transform posUp;
    public Transform posDown;
    public Vector2 boxSize;
    public int damage;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        isMoving = false;
        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(X, Y);

    }

    
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if (!isMoving)
        {
            System.Func<KeyCode, bool> inputFuction;
            if (isRepeatedMovement)
            {
                inputFuction = Input.GetKey;
            }
            else
            {
                inputFuction = Input.GetKeyDown;
            }

            if (inputFuction(KeyCode.UpArrow))
            {
                if (currentTile.canMoveUp)
                {
                    movingLimit -= 1;
                    ani.SetTrigger("Up");
                    StartCoroutine(Move(Vector2.up));
                }
                
            }
            else if (inputFuction(KeyCode.DownArrow))
            {
                if (currentTile.canMoveDown)
                {
                    movingLimit -= 1;
                    ani.SetTrigger("Down");
                    StartCoroutine(Move(Vector2.down));
                }
            }
            if (inputFuction(KeyCode.LeftArrow))
            {
                if (currentTile.canMoveLeft)
                {

                    movingLimit -= 1;
                    ani.SetTrigger("Left");
                    StartCoroutine(Move(Vector2.left));
                }
            }
            if (inputFuction(KeyCode.RightArrow))
            {
                if (currentTile.canMoveRight)
                {

                    movingLimit -= 1;
                    ani.SetTrigger("Right");
                    StartCoroutine(Move(Vector2.right));
                }
            }

           
        }
    }

    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;

        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * gridSize);

        X = endPosition.x;
        Y = endPosition.y;

        float elapsedTime = 0;
        while(elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        isMoving = false;
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            Collider2D[] leftCollider2D = Physics2D.OverlapBoxAll(posLeft.position, boxSize, 0);
            foreach (Collider2D item in leftCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("left");
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                }

            }

            ani.SetTrigger("Attack1");
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            Collider2D[] upCollider2D = Physics2D.OverlapBoxAll(posUp.position, boxSize, 0);
            foreach (Collider2D item in upCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("up");
                    item.GetComponent<ThisIsBox>().TakeDamage(1);
                }

            }
            ani.SetTrigger("Attack2");
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            Collider2D[] rightCollider2D = Physics2D.OverlapBoxAll(posRight.position, boxSize, 0);
            foreach (Collider2D item in rightCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("right");
                    item.GetComponent<ThisIsBox>().TakeDamage(1);
                }

            }
            ani.SetTrigger("Attack3");
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            Collider2D[] downCollider2D = Physics2D.OverlapBoxAll(posDown.position, boxSize, 0);
            foreach (Collider2D item in downCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("down");
                    item.GetComponent<ThisIsBox>().TakeDamage(1);
                }

            }
            ani.SetTrigger("Attack4");
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag ("Enemy"))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                actionLimit -= 1;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Tile"))
        {
            currentTile = other.GetComponent<Tile>();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(posLeft.position, boxSize);
        Gizmos.DrawWireCube(posRight.position, boxSize);
        Gizmos.DrawWireCube(posUp.position, boxSize);
        Gizmos.DrawWireCube(posDown.position, boxSize);
    }
}
