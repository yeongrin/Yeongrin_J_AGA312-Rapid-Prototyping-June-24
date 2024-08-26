using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController6 : MonoBehaviour
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
    Rigidbody rigid;
    public int movingLimit;
    public int actionLimit;

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
    public Vector3 boxSize;
    public Vector2 boxSize2;
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
        rigid = GetComponent<Rigidbody>();
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
                Vector3 direction = Vector3.up;
                RaycastHit hit;
                Debug.DrawRay(rigid.position, Vector2.up, new Color(checkDistance, 0, 0));
                //Debug.Log(hit.collider.name);

                if (Physics.Raycast(transform.position, direction, out hit, checkDistance, obstacleLayer))
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
                Vector3 direction = Vector3.down;
                RaycastHit hit;
                Debug.DrawRay(rigid.position, Vector2.down, new Color(checkDistance, 0, 0));

                if (Physics.Raycast(transform.position, direction, out hit, checkDistance, obstacleLayer))
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
                Vector3 direction = Vector3.left;
                RaycastHit hit;
                Debug.DrawRay(rigid.position, Vector2.left, new Color(checkDistance, 0, 0));

                if (Physics.Raycast(transform.position, direction, out hit, checkDistance, obstacleLayer))
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
                Vector3 direction = Vector3.right;
                RaycastHit hit;
                Debug.DrawRay(rigid.position, Vector2.right, new Color(checkDistance, 0, 0));

                if (Physics.Raycast(transform.position, direction, out hit, checkDistance, obstacleLayer))
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
        while (elapsedTime < moveDuration)
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
            Collider[] leftCollider = Physics.OverlapBox(posLeft.position, boxSize, transform.rotation, 0);
                Debug.Log($"Colliders found: {leftCollider.Length}");
            foreach (Collider item in leftCollider)
            {
                Debug.Log("left");
                if (item.tag == "Enemy2")
                {
                    item.GetComponent<Canwarm>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Target")
                {
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                }
            } 

            //Collider2D[] leftCollider2D = Physics2D.OverlapBoxAll(posLeft.position, boxSize2, 0);
            //foreach (Collider2D item in leftCollider2D)
            //{
            //    if (item.tag == "Target")
            //    {
            //        item.GetComponent<ThisIsBox>().TakeDamage(damage);
            //    }
            //}

        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack2");
            aniUp.SetTrigger("Up"); //Animation and Sound effect

            //Hit the enemy and box
            Collider[] upCollider = Physics.OverlapBox(posUp.position, boxSize, transform.rotation, 0);
            foreach (Collider item in upCollider)
            {
                Debug.Log("Up");
                if (item.tag == "Enemy2")
                {
                    item.GetComponent<Canwarm>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Target")
                {
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                }
            }

            //Collider2D[] upCollider2D = Physics2D.OverlapBoxAll(posUp.position, boxSize2, 0);
            //foreach (Collider2D item in upCollider2D)
            //{
            //    if (item.tag == "Target")
            //    {
            //        item.GetComponent<ThisIsBox>().TakeDamage(damage);
            //    }

            //}

        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack3");
            aniRight.SetTrigger("Right"); //Animation and Sound effect

            //Hit the enemy and box
            Collider[] rightCollider = Physics.OverlapBox(posRight.position, boxSize, transform.rotation, 0);
            foreach (Collider item in rightCollider)
            {
                Debug.Log("Right");
                if (item.tag == "Enemy2")
                {
                    item.GetComponent<Canwarm>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Target")
                {
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                }
            }

            //Collider2D[] rightCollider2D = Physics2D.OverlapBoxAll(posRight.position, boxSize2, 0);
            //foreach (Collider2D item in rightCollider2D)
            //{
            //    if (item.tag == "Target")
            //    {
            //        item.GetComponent<ThisIsBox>().TakeDamage(damage);
            //    }


            //}
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            audiosource.Play();
            ani.SetTrigger("Attack4");
            aniDown.SetTrigger("Down"); //Animation and Sound effect

            //Hit the enemy and box
            Collider[] downCollider = Physics.OverlapBox(posDown.position, boxSize, transform.rotation, 0);
            foreach (Collider item in downCollider)
            {
                Debug.Log("Down");
                if (item.tag == "Enemy2")
                {
                    item.GetComponent<Canwarm>().TakeDamage(damage);
                    actionLimit -= 1;
                }

                if (item.tag == "Target")
                {
                    item.GetComponent<ThisIsBox>().TakeDamage(damage);
                }
            }

            //Collider2D[] downCollider2D = Physics2D.OverlapBoxAll(posDown.position, boxSize2, 0);
            //foreach (Collider2D item in downCollider2D)
            //{
            //    if (item.tag == "Target")
            //    {
            //        item.GetComponent<ThisIsBox>().TakeDamage(damage);
            //    }
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            currentTile = other.GetComponent<Tile>();
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            movingLimit -= 1;
            StartCoroutine("NuckBack");
        }
        if(other.gameObject.CompareTag("Enemy2"))
        {
            actionLimit -= 1;
            movingLimit -= 1;
            Debug.Log("aw!");
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
    
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(posLeft.position, boxSize);
        Gizmos.DrawWireCube(posRight.position, boxSize);
        Gizmos.DrawWireCube(posUp.position, boxSize);
        Gizmos.DrawWireCube(posDown.position, boxSize);

        Gizmos.DrawWireCube(posLeft.position, boxSize2);
        Gizmos.DrawWireCube(posRight.position, boxSize2);
        Gizmos.DrawWireCube(posUp.position, boxSize2);
        Gizmos.DrawWireCube(posDown.position, boxSize2);
    }

}
