using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum RespawnSpace { level1, level2, level3, level4, level5 };

    [Header("enemy state")]
    public static int enemyHealth = 5;
    public static int bossHealth = 20;
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;

    [Header("Respawn")]
    public float threshold;
    public float spawnRange = 10f;
    public RespawnSpace space;
    //public Transform respawn;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        switch (space)
        {
            case RespawnSpace. level1:
                {
                    RespawnEnemy();
                }
                break;
            case RespawnSpace. level2:
                {
                    RespawnEnemy2();
                }
                break;

            case RespawnSpace.level3:
                {
                    if (enemyHealth <= 0)
                    {
                        Destroy(this.gameObject);
                    }
                    //RespawnEnemy3;
                }
                break;

            case RespawnSpace.level4:
                {
                    
                    RespawnEnemy4();
                }
                break;

            case RespawnSpace.level5:
                {
                    if (bossHealth <= 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;
        }
        
    }

    void RespawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        if (transform.position.y < threshold)
        {
            //Transform _sp = respawn[Random.Range(0, respawn.Length)];
            transform.position = new Vector3(spawnPosX, 0, spawnPosZ);
            
        }

    }

    void RespawnEnemy2()
    {
        if (transform.position.y < threshold)
        {
            
            transform.position = new Vector3(0.3f, 2f, 35f);
        }
    }

    void RespawnEnemy4()
    {
        Debug.Log("gkgkgkgk");
    }

}
