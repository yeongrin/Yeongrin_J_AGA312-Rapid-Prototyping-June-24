using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPoint;
    public Rigidbody body;
    public float speed;
    public float lineOfCircle;
    Timer timer;

    void Start()
    {
        timer = GameObject.Find("GameManager").GetComponent<Timer>();
        targetPoint = GameObject.FindWithTag("Finish").GetComponent<Transform>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(10, 20);
        agent.angularSpeed = Random.Range(150, 180);
        agent.acceleration = Random.Range(150, 180);
    }

    void Update()
    {
        //Vector3 Direction = (targetPoint.transform.position - transform.position).normalized;
        //body.AddForce(lookDirection * speed);

        float lookDirection = Vector3.Distance(targetPoint.position ,transform.position);
        {
            if (lookDirection < lineOfCircle)
            {
                //transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
                agent.SetDestination(targetPoint.position);
            }
           
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfCircle);
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            GameManager3.enemyScore += 1;
            timer.currentTime += 5f;
            Destroy(this.gameObject);
        }

        if(collider.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
