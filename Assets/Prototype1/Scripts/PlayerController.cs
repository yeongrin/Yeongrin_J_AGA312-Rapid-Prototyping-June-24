using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    //public bool hasAttckUp = false;
    public GameObject powerUpIndicator;//Powerup 1
    public GameObject damageIndicator2; //Powerup2

    [Header("Moving")]
    private Rigidbody playerRB;
    public float speed;
    public float jump;

    [Header("Jump")]
    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckDistance = 0.1f;

    [Header("Player attack")]
    public int playerDamage;//PowerUp 1 can plus 
    public int playerArmor;//Power Up 1 can plus
    public int playerHealth;//Power up 2 can plus

    private float powerUpStrength = 6f;

    [Header ("Respawn")]
    public float threshold;
    public Transform respawn;

    void Start()
    {
        playerDamage = 0;
        playerArmor = 0;

        playerRB = GetComponent<Rigidbody>();
        //focalPoint = GameObject.Find("Focal Point");
       
    }

    void Update()
    {
        GameManager.GM();

        //float forwardInput = Input.GetAxis("Vertical");
        //playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);

        //Moving direction
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        playerRB.AddForce(direction * speed);
            
        //Jump
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        powerUpIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
        damageIndicator2.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            playerHealth -= 1;
            GameManager.GM();
            transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player's Defense Up. If you have this, it protect enemy attacks and destroy them.
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            //hasAttckUp = true;

            playerArmor += 1;
            playerDamage += 1;
            GameManager.GM();

            powerUpIndicator.gameObject.SetActive(true);
            damageIndicator2.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            //StartCoroutine(PowerUpCountDown2());
            
            Debug.Log("2535");
        }

        //Player's Damage Up. If you have this, player can recover their health.

        if (other.CompareTag("PowerUp2"))
        {

            playerHealth += 1;
            GameManager.GM();

            Destroy(other.gameObject);

        }

        if (other.CompareTag("PowerUp3"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountDown3());
            playerArmor += 1;
            playerDamage += 1;
            GameManager.GM();

            Destroy(other.gameObject);

        }

        if (other.CompareTag("Trophy"))
        {

            GameManager.score += 20;
            GameManager.GM();

            Destroy(other.gameObject);

        }
        
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(12);
        hasPowerUp = false;
        //hasAttckUp = true;
        powerUpIndicator.gameObject.SetActive(false);
        playerArmor -= playerArmor;
        playerDamage -= playerDamage;

        GameManager.GM();
    }

    /*IEnumerator PowerUpCountDown2()
    {
        yield return new WaitForSeconds(10);
        hasAttckUp = false;
        damageIndicator2.gameObject.SetActive(false);
        playerDamage -= 1;

        GameManager.GM();
    }*/

    IEnumerator PowerUpCountDown3()
    {
        yield return new WaitForSeconds(20);
        hasPowerUp = false;
        //hasAttckUp = true;
        powerUpIndicator.gameObject.SetActive(false);
        playerArmor -= playerArmor;
        playerDamage -= playerDamage;

        GameManager.GM();
    }

    //All attacks and defenses only work when the count is 1 or higher.
    void OnCollisionEnter(Collision collision)
    {
        //Players are not damaged even if they are attacked by enemies.
        //The player attacks the enemy and get the score
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            
            Destroy(collision.gameObject);
            GameManager.score += 1;
            GameManager.GM();
            
        }

        else
        {
            //Players are attacked by enemies if they do not power up.
            if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == false)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

                enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
                playerHealth -= 1;
                GameManager.GM();
            }
        }

        if (collision.gameObject.CompareTag("Enemy2") && hasPowerUp)
        {
            powerUpStrength = 8f;
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
            Enemy.enemyHealth -= 1;

            if (Enemy.enemyHealth == 0)
            {
                GameManager.score += 2;
                GameManager.GM();

            }
        }
        //Players are attacked by enemies and bounced off if they do not power up.
        else
        {
            if(collision.gameObject.CompareTag("Enemy2") && hasPowerUp == false)
            {
                powerUpStrength = 5f;
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

                enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
                playerHealth -= 2;
                GameManager.GM();
            }
        }

        if (collision.gameObject.CompareTag("BossEnemy") && hasPowerUp)
        {
            Enemy.bossHealth -= 1;

            if (Enemy.bossHealth == 0)
            {
                GameManager.score += 25;
                GameManager.GM();

            }
        }
        //Players are attacked by enemies and bounced off if they do not power up.
        else
        {
            if (collision.gameObject.CompareTag("BossEnemy") && hasPowerUp == false)
            {
                powerUpStrength = 2f;
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

                enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
                playerHealth -= 3;
                GameManager.GM();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
