using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    PlayerController5 player5;
    public int limit;

    void Start()
    {
        player5 = gameObject.GetComponent<PlayerController5>();
       
    }

    void Update()
    {
        
    }

    public void HitPlayer()
    {
      
    }
}
