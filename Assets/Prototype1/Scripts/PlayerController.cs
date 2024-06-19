using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public float speed;
    public float jump;
    public bool hasPowerUp = false;
    public bool hasAttckUp = false;
    public GameObject powerUpIndicator;//Powerup 1
    public GameObject damageIndicator2; //Powerup2

    [Header("Jump")]
    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckDistance = 0.1f;

    [Header("Player attack")]
    public int playerDamage;
    public int playerArmor;
    public int playerHealth;
    private float powerUpStrength = 10f;

    [Header ("Respawn")]
    public float threshold;
    public Transform respawn;

    void Start()
    {
        playerDamage = 0;
        playerArmor = 0;
        playerHealth = 5;

        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        GameManager.GM();

        //Moving vertical
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
        damageIndicator2.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        //Jump
        
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
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
        //Player's Defense Up. If you have this, it bounces off enemy attacks
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;

            playerArmor += 1;
            playerHealth += 1;
            GameManager.GM();

            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            
            Debug.Log("2535");
        }

        //Player's Damage Up. If you have this, it destroys enemies.
        if (other.CompareTag("PowerUp2"))
        {
            hasAttckUp = true;
           
            playerDamage += 1;
            GameManager.GM();

            damageIndicator2.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown2());

        }
        
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
        playerArmor -= 1;

        GameManager.GM();
    }

    IEnumerator PowerUpCountDown2()
    {
        yield return new WaitForSeconds(10);
        hasAttckUp = false;
        damageIndicator2.gameObject.SetActive(false);
        playerArmor -= 1;

        GameManager.GM();
    }

    //All attacks and defenses only work when the count is 1 or higher.
    void OnCollisionEnter(Collision collision)
    {
        //Players are not damaged even if they are attacked by enemies.
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
            GameManager.GM();
            
        }
        //The player attacks the enemy and get the score
        if (collision.gameObject.CompareTag("Enemy") && hasAttckUp)
        {
            Destroy(collision.gameObject);
            GameManager.score += 1;
        }

        /*else
        {
            //Players are attacked by enemies if they do not power up.
            if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == false)
            {
                playerHealth -= 1;
                GameManager.GM();
            }
        }*/

        if (collision.gameObject.CompareTag("Enemy2") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
            GameManager.score += 2;
            GameManager.GM();
        }
        //Players are attacked by enemies if they do not power up.
        if (collision.gameObject.CompareTag("Enemy2") && hasPowerUp == false)
        {
            playerHealth -= 1;
            GameManager.GM();
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
