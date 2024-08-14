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
    public int movingLimit ;
    public int actionLimit ;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        isMoving = false;
    }

    
    void Update()
    {
        Move();
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
                movingLimit -= 1;
                ani.SetTrigger("Up");
                StartCoroutine(Move(Vector2.up));
            }
            else if (inputFuction(KeyCode.DownArrow))
            {
                movingLimit -= 1;
                ani.SetTrigger("Down");
                StartCoroutine(Move(Vector2.down));
            }
            if (inputFuction(KeyCode.LeftArrow))
            {
                movingLimit -= 1;
                ani.SetTrigger("Left");
                StartCoroutine(Move(Vector2.left));
            }
            if (inputFuction(KeyCode.RightArrow))
            {
                movingLimit -= 1;
                ani.SetTrigger("Right");
                StartCoroutine(Move(Vector2.right));
            }
        }
    }

    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;

        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * gridSize);

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

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag ("Enemy"))
        {
            if(Input.GetKeyDown("Z"))
            {
                actionLimit -= 1;
            }
        }
    }
}
