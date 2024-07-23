using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Forces : MonoBehaviour
{
    public NavMeshAgent forces;
    public Transform targetPoint;
    public Rigidbody body;
    public float speed;
    public float lineOfCircle;
    Timer timer;

    void Start()
    {
        targetPoint = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        forces = this.gameObject.GetComponent<NavMeshAgent>();
        timer = GameObject.Find("GameManager").GetComponent<Timer>();
    }

    void Update()
    {
        //Vector3 Direction = (targetPoint.transform.position - transform.position).normalized;
        //body.AddForce(lookDirection * speed);

        float lookDirection = Vector3.Distance(targetPoint.position, transform.position);
        {
            if (lookDirection < lineOfCircle)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
                forces.SetDestination(targetPoint.position);
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
        if(collider.gameObject.CompareTag("Bullet"))
        {
            GameManager3.forceScore -= 1;
            timer.currentTime -= 5;
            Destroy(this.gameObject);
        }

        if(collider.gameObject.CompareTag("Another"))
        {
            Destroy(this.gameObject);
        }
    }
}
