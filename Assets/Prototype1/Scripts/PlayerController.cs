using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalPoint;
    private float powerUpStrength = 10f;
    public float speed;
    public float jump;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;

    [Header("Jump")]
    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckDistance = 0.1f;

    [Header("Player attack")]
    public int playerDamage;
    public int playerArmor;
    public int playerHealth = 5;

    void Start()
    {
        playerDamage = 0;
        playerArmor = 0;

        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        //Moving vertical
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);

        //Jump
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());

            playerArmor += 1;
            playerDamage += 1;
            //Fire.fire();
            Debug.Log("2535");
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
        playerArmor -= 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            GameManager.GM();
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("Enemy2") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awatFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awatFromPlayer * powerUpStrength, ForceMode.Impulse);
            Destroy(collision.gameObject);
            GameManager.GM();
        }
    }
}
