using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    public static Action fire;

    public Transform firePosT;
    public GameObject firePos;

    [Header ("Bullet")]
    public int speed;
    public GameObject weapon;
    public int bulletCount = 0;
   

    private void Awake()
    {
        fire = () => { GetBullet(); };
    }

    void Start()
    {
        bulletCount = 0;
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit pos;
        if(Physics.Raycast(ray, out pos, Mathf.Infinity))
        {
            transform.LookAt(pos.point);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

       if (bulletCount >= 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(weapon, firePos.transform.position, firePos.transform.rotation);
                bulletCount -= 1;
                weapon.GetComponent<Rigidbody>().velocity = firePosT.forward * speed;

            }

        }

       firePos.transform.position = transform.position + new Vector3(0, 0, 1f);
    }

    public void GetBullet()
    {
        bulletCount += 1;
    }

}
