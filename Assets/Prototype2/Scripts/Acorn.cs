using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{ 
    Acorn,
    Cherry
}

public class Acorn : MonoBehaviour
{
    public int score;
    public bool isFalling;
    Rigidbody2D rb;
    Animator ani;

    public ItemType itemType;
    public float timer;

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
                    if(Input.GetKeyDown(KeyCode.X)&&isPlayerEnter)
                    {
                        transform.SetParent(playerEquipPoint.transform);
                        transform.localPosition = Vector3.zero;
                        transform.rotation = new Quaternion(0, 0, 0, 0);

                        isPlayerEnter = false;
                    }
                }
                break;
            case ItemType.Cherry:
                {
                    timer += Time.deltaTime;
                    score = 3;
                    if(timer >= 10)
                    {
                        Destroy(this.gameObject);
                    }
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Another"))
        {
            Destroy(this.gameObject);
            //score += 1;
        }
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerEnter = true;
            
        }
    }
}
