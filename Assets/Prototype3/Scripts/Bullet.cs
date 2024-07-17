using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisitonExplosion;
    public float speed;

    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if(m_target != null)
        {
            if(transform.position == m_target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void explode()
    {
        if(collisitonExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(collisitonExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }


        if (collider.gameObject.CompareTag("Enemy2"))
        {
            Destroy(this.gameObject);
        }
       
    }

}
