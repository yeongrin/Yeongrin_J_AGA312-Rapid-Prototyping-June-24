using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Caterpillar,
    Owl,
    Bee,
    Snail
}

public class EnemyP2 : MonoBehaviour
{
    public EnemyType enemyType;
    public int enemyAttackDamage;
    public int enemySpeed;
    public int normalSpeed = 1;

    [Header("CaterlillarMoving")]
    public float firstTransformX;
    public float firstTransformY;
    public float currentTransformX;
    public float currentTransformY;
    Animator ani;

   
    private Rigidbody2D body;
    private SpriteRenderer render;

    //EnemySpawnP2 _ES2;

    void Start()
    {
        //_ES2 = _ES2.GetComponent<EnemySpawnP2>();
        firstTransformX = transform.position.x;
        firstTransformY = transform.position.y;

        currentTransformX = transform.position.x;
        currentTransformY = transform.position.y;

        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.Caterpillar:
                {
                    enemyAttackDamage = 1;
                    enemySpeed = normalSpeed * 3;
                    
                    if (firstTransformX < 0)
                    {
                        Flip();
                        ani.SetTrigger("isMoving");
                        currentTransformX += Time.deltaTime * enemySpeed;

                        if (currentTransformX >= 11)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                    if(firstTransformX > 0)
                    {
                        ani.SetTrigger("isMoving");
                        currentTransformX -= Time.deltaTime * enemySpeed;

                        if (currentTransformX <= -11)
                        {
                            Destroy(this.gameObject);
                        }
                    }

                    transform.position = new Vector3(currentTransformX, firstTransformY, 0);

                }
                break;

            case EnemyType.Snail:
                {
                   
                }
                break;


            case EnemyType.Owl:
                {
                    enemyAttackDamage = 2;
                    enemySpeed = normalSpeed * 5;
                }
                break;

            case EnemyType.Bee:
                {
                    enemyAttackDamage = 2;
                    enemySpeed = normalSpeed * 4;

                    currentTransformY -= Time.deltaTime * enemySpeed;
                    transform.position = new Vector3(firstTransformX, currentTransformY, 0);
                }
                break;
        }

        if(currentTransformY <= -7 )
        {
            Destroy(this.gameObject);
        }

    }

    void Flip()
    {
        render.flipX = firstTransformX < 0f;
    }

   
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
  
}
