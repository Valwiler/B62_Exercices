using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health hp;
    public GameObject Player;
    public float Speed;
    public Vector3 scale;
    void Start()
    {
        Player = GameObject.Find("player");
        transform.localScale = scale;
        hp = GetComponent<Health>();
    }
    void Awake()
    {
        
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        //Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Kinematic;
        //rb.gravityScale = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        transform.position = Vector3.MoveTowards(transform.position,
            Player.transform.position,
            Speed * Time.deltaTime);
        if ( hp.Hp <= 0 )
        {
            Destroy(gameObject);
        }
    }

    void LookAtPlayer()
    {
        
        Vector2 direction = (Vector2)Player.transform.position - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle ));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectiles"))
        {
            hp.substractHealth();
        }
     
    }
}
