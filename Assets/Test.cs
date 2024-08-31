using TMPro.Examples;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int enemyHealth;
    public int score;
    public Animator ani;

    Collider col;

    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveDirection = new Vector2(1f, 0.25f);
    [SerializeField] GameObject rightCheck, leftCheck, roofCheck, groundCheck;
    [SerializeField] Vector2 rightCheckSize, leftCheckSize, roofCheckSize, groundCheckSize;
    [SerializeField] LayerMask groundLayer, platform;
    [SerializeField] bool goingUp = true;

    private bool touchedGround, touchedRoof, touchedRight, tourchedLeft;
    private Rigidbody EnemyRB;

    int hitCount;

    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();

        hitCount = 0;
    }

    void Update()
    {
        HitLogic();
    }

    void FixedUpdate()
    {
        EnemyRB.velocity = moveDirection * moveSpeed;
    }

    void HitLogic()
    {
        touchedRight = HitDetector(rightCheck, rightCheckSize, (groundLayer));
        tourchedLeft = HitDetector(leftCheck, leftCheckSize, (groundLayer));
        touchedRoof = HitDetector(roofCheck, roofCheckSize, (groundLayer));
        touchedGround = HitDetector(groundCheck, groundCheckSize, (groundLayer));

        if (touchedRight)
        {
            //Debug.Log("right");
            Flip();
           
        }
        if(tourchedLeft)
        {
            Flip();
        }
        if (touchedRoof && goingUp)
        {
            ChangeYDirection();
        }
        if (touchedGround && !goingUp)
        {
            ChangeYDirection();
        }
    }

    bool HitDetector(GameObject gameObject, Vector2 size, LayerMask layer)
    {
        return Physics.CheckBox(gameObject.transform.position, size, Quaternion.identity, layer);
    }

    void ChangeYDirection()
    {
        moveDirection.y = -moveDirection.y;
        goingUp = !goingUp;
    }

    void Flip()
    {
        //transform.Rotate(new Vector3(0, 180, 0));
        moveDirection.x = -moveDirection.x;
        //Debug.Log("Hit");
    }

        public void TakeDamage(int damage)
    {
        //ani.SetTrigger("turnRed");
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            col.enabled = false;
            ani.SetTrigger("Death");
        }

    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheck.transform.position, groundCheckSize);
        Gizmos.DrawWireCube(leftCheck.transform.position, leftCheckSize);
        Gizmos.DrawWireCube(roofCheck.transform.position, roofCheckSize);
        Gizmos.DrawWireCube(rightCheck.transform.position, rightCheckSize);
    }
}