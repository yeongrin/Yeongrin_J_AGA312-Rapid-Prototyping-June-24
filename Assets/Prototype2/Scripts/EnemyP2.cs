using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Caterpillar,
    Owl,
    Spider
}

public class EnemyP2 : MonoBehaviour
{
    public EnemyType enemyType;
    public int enemyAttackDamage;
    public int enemySpeed;
    public int normalSpeed = 1;
    public float currentTransformX;
    public float currentTransformY;

    //EnemySpawnP2 _ES2;

    void Start()
    {
        //_ES2 = _ES2.GetComponent<EnemySpawnP2>();
        currentTransformX = transform.position.x;
        currentTransformY = transform.position.y;

    }

    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.Caterpillar:
                {
                    enemyAttackDamage = 1;
                    enemySpeed = normalSpeed * 3;
                    
                    if (currentTransformX <= 0)
                    {
                        currentTransformX += Time.deltaTime * enemySpeed;

                        if (currentTransformX >= 11)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                    if(currentTransformX > 0)
                    {
                        currentTransformX -= Time.deltaTime * enemySpeed;

                        if (currentTransformX <= -11)
                        {
                            Destroy(this.gameObject);
                        }
                    }

                    transform.position = new Vector3(currentTransformX, currentTransformY, 0);

                }
                break;

            case EnemyType.Owl:
                {
                    enemyAttackDamage = 2;
                    enemySpeed = normalSpeed * 5;
                }
                break;

            case EnemyType.Spider:
                {
                    enemyAttackDamage = 3;
                    enemySpeed = normalSpeed * 4;
                }
                break;
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}
