using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController5 : MonoBehaviour
{
    [SerializeField] private bool isRepeatedMovement = false;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;

    [Header("Animation")]
    Animator ani;
    AudioSource audiosource;
    public Animator aniLeft;
    public Animator aniRight;
    public Animator aniUp;
    public Animator aniDown;
    SpriteRenderer spriteRenderer;

    [Header("Moving account")]
    public bool isMoving = false;
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

    [Header("Raycast")]
    public LayerMask obstacleLayer; //Raycast block layer
    public float checkDistance;
    public bool canMoving = true;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        isMoving = false;
        canMoving = true;
        rigid = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

            //Move up
            if (inputFuction(KeyCode.UpArrow))
            {
                float moveInput = transform.up.y;
                Vector2 direction = Vector2.up;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, obstacleLayer);
                Debug.DrawRay(rigid.position, Vector2.up, new Color(0, checkDistance, 0));
                //Debug.Log(hit.collider.name);

                if (hit.collider != null)
                {
                    //If raycast2d hits something the player can't move
                    canMoving = false;
                    if (canMoving == false)
                    {
                        return;
                        //canMoving = true;
                    }
                }
                else
                {
                    //else raycast2d hits nothing the player can move
                    canMoving = true;
                    if (canMoving == true)
                    {
                        ani.SetTrigger("Up");
                        StartCoroutine(Move(Vector2.up));
                    }
                }
    
            }

            //Move Down
            else if (inputFuction(KeyCode.DownArrow))
            {

                float moveInput = -transform.up.y;
                Vector2 direction = Vector2.down;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, obstacleLayer);
                Debug.DrawRay(rigid.position, Vector2.down, new Color(0, checkDistance, 0));

              if (hit.collider != null)
                {
                    canMoving = false;
                    if (canMoving == false)
                    {
                        return;
                        //canMoving = true;
                    }
                }
                else
                {
                    canMoving = true;
                    if (canMoving == true)
                    {
                        ani.SetTrigger("Down");
                        StartCoroutine(Move(Vector2.down));

                    }
                }

            }
            //Move Left
            if (inputFuction(KeyCode.LeftArrow))
            {
                float moveInput = -transform.right.x;
                Vector2 direction = Vector2.left;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, obstacleLayer);
                Debug.DrawRay(rigid.position, Vector2.left, new Color(checkDistance, 0, 0));

                if (hit.collider != null)
                {
                    canMoving = false;

                    if (canMoving == false)
                    {
                        return;
                        //canMoving = true;
                    }

                }
                else
                {
                    canMoving = true;
                    if (canMoving == true)
                    {
                        ani.SetTrigger("Left");
                        StartCoroutine(Move(Vector2.left));

                    }

                    //if (currentTile.canMoveLeft)
                    //{
                    //    Debug.Log("left");
                    //    movingLimit -= 1;
                    //    ani.SetTrigger("Left");
                    //    StartCoroutine(enumerator3);
                    //}
                }

            }
            //Move Right
            if (inputFuction(KeyCode.RightArrow))
            {
                float moveInput = transform.right.x;
                Vector2 direction = Vector2.right;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, checkDistance, obstacleLayer);
                Debug.DrawRay(rigid.position, Vector2.right, new Color(checkDistance, 0, 0));

                if (hit.collider != null)
                {
                    canMoving = false;

                    if (canMoving == false)
                    {
                        return;
                        //canMoving = true;
                    }
                }
                else
                {
                    canMoving = true;
                    if (canMoving == true)
                    {
                        ani.SetTrigger("Right");
                        StartCoroutine(Move(Vector2.right));
                    }
                }
           
            }
        }
    }

    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;

        movingLimit -= 1;

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
            audiosource.Play();
            ani.SetTrigger("Attack1");
            aniLeft.SetTrigger("Left"); //Animation and Sound effect

            //Hit the enemy and box
            Collider2D[] leftCollider2D = Physics2D.OverlapBoxAll(posLeft.position, boxSize, 0);
            foreach (Collider2D item in leftCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("left");
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Enemy")
                {
                    item.GetComponent<TrashEnemies>().TakeDamage(damage);
                    actionLimit -= 1;
                }
            }

           
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack2");
            aniUp.SetTrigger("Up"); //Animation and Sound effect

            //Hit the enemy and box
            Collider2D[] upCollider2D = Physics2D.OverlapBoxAll(posUp.position, boxSize, 0);
            foreach (Collider2D item in upCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("up");
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Enemy")
                {
                    item.GetComponent<TrashEnemies>().TakeDamage(damage);
                    actionLimit -= 1;
                }
            }
               
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack3");
            aniRight.SetTrigger("Right"); //Animation and Sound effect

            //Hit the enemy and box
            Collider2D[] rightCollider2D = Physics2D.OverlapBoxAll(posRight.position, boxSize, 0);
            foreach (Collider2D item in rightCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("right");
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Enemy")
                {
                    item.GetComponent<TrashEnemies>().TakeDamage(damage);
                    actionLimit -= 1;


                }
            }
                
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack4");
            aniDown.SetTrigger("Down"); //Animation and Sound effect

            //Hit the enemy and box
            Collider2D[] downCollider2D = Physics2D.OverlapBoxAll(posDown.position, boxSize, 0);
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, checkDistance, 0));

            foreach (Collider2D item in downCollider2D)
            {
                if (item.tag == "Target")
                {
                    Debug.Log("down");
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Enemy")
                {
                    item.GetComponent<TrashEnemies>().TakeDamage(damage);
                    actionLimit -= 1;

                }

            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Tile"))
        {
            //Normal platform
            currentTile = other.GetComponent<Tile>();
           
        }
        
        if(other.gameObject.CompareTag("Platform"))
        {
            //Lava
            movingLimit -= 1;
            StartCoroutine("NuckBack");
        }
    }
    IEnumerator NuckBack()
    {
        for (int i = 1; i < 2; i++)
        {

            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        //for (int i = 1; i < 4; i++)
        //{
        //    yield return new WaitForSeconds(0.4f);

        //}

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
