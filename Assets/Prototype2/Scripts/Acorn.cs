using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ItemType
{ 
    Acorn,
    Cherry
}

public class Acorn : MonoBehaviour
{
    //public static Action arcorn;
    public ItemType itemType;
    
    public float timer;
    public int score;
    public bool isFalling;
    Rigidbody2D rb;
    Animator ani;

    GameObject player;
    GameObject playerEquipPoint;
    PlayerController2 playerLogic;

    Vector3 forceDirection;
    bool isPlayerEnter;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");

        playerLogic = player.GetComponent<PlayerController2>();

        //arcorn = () => { DropDown(); };
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        ani = GetComponent<Animator>();
        timer = 0f;
    }

    
    void Update()
    {
        
        switch (itemType)
        {
            case ItemType.Acorn:
                {
                    score = 1;
                    if(Input.GetKeyDown(KeyCode.Space) && isPlayerEnter)
                    {
                        transform.SetParent(playerEquipPoint.transform);
                        transform.localPosition = Vector3.zero;
                        transform.rotation = new Quaternion(0, 0, 0, 0);

                        playerLogic.PickUp(gameObject);
                        isPlayerEnter = false;
                    }
                }
                break;
            case ItemType.Cherry:
                {
                    timer += Time.deltaTime;
                    score = 3;

                    if (Input.GetKeyDown(KeyCode.X) && isPlayerEnter)
                    {
                        transform.SetParent(playerEquipPoint.transform);
                        transform.localPosition = Vector3.zero;
                        transform.rotation = new Quaternion(0, 0, 0, 0);

                        if (playerLogic.health < 5)
                        {
                            playerLogic.health += 1;
                            Destroy(this.gameObject);

                        }
                        else
                        {
                            if(playerLogic.health >= 5)
                            Destroy(this.gameObject);
                        }
                        isPlayerEnter = false;
                    }
                    
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Another"))
        {
            GameManager2.score -= 1;
            GameManager2._GM2();
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerEnter = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
