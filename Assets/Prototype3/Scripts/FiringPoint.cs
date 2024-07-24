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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
            FireRaycast();
        }
        Debug.DrawRay(transform.position, transform.forward * 500f, Color.red);
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
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit, range))
        //{
        //    GameObject laserShoot = GameObject.Instantiate(sparkle, transform.position, transform.rotation) as GameObject;
        //    laserShoot.GetComponent<Bullet>().setTarget(hit.point);
        //    GameObject.Destroy(laserShoot, 0.5f);
        //}

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            // If the ray hits something, you can access information about the hit
            Debug.Log("Ray hit: " + hit.collider.name);

            // Example: If you want to do something with the object that was hit
            GameObject hitObject = hit.collider.gameObject;

            // Do something with hitObject...
            //GameObject particles = Instantiate(sparkle, hit.point, hit.transform.rotation);
            //Destroy(particles, 1);

           laser.SetPosition(0, transform.position);
           laser.SetPosition(1, hit.point);
           StartCoroutine(StopLaser());

            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("Enemy2"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            // If the ray does not hit anything
            Debug.Log("Ray did not hit anything.");
        }

        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    laser.SetPosition(0, transform.position);
        //    laser.SetPosition(1, hit.point);
        //    StartCoroutine(StopLaser());
        //}

    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.gameObject.SetActive(false);
    }
}
