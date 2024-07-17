using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    public LineRenderer laser;
    public GameObject sparkle;

    public float range;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
            FireRaycast();
        }
    }

    void Shoot()
    {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce
           (transform.forward * projectileSpeed);

    }

    void FireRaycast()
    {
        // Ray ray = new Ray(transform.position, transform.forward);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit, range))
        //{
        //    GameObject laserShoot = GameObject.Instantiate(sparkle, transform.position, transform.rotation) as GameObject;
        //    laserShoot.GetComponent<Bullet>().setTarget(hit.point);
        //    GameObject.Destroy(laserShoot, 0.5f);
        //}

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);
            StartCoroutine(StopLaser());

            GameObject particles = Instantiate(sparkle, hit.point, hit.transform.rotation);
            Destroy(particles, 1);

            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
            if(hit.collider.CompareTag("Enemy2"))
            {
                Destroy(hit.collider.gameObject);
            }

        }
        
    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.gameObject.SetActive(false);
    }
}
