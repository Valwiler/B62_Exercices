using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public Health hp;
    public GameObject Player;
    public float Speed;
    public Vector3 scale;
    public Player playerValues;
    void Start()
    {
        Player = GameObject.Find("player");
        playerValues = Player.GetComponent<Player>();
        transform.localScale = scale;
        hp = GetComponent<Health>();
        
    }
    void Awake()
    {
        
        gameObject.AddComponent<BoxCollider2D>();
        ;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
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
            if (Speed > 3)
            {
                playerValues.increaseScore( 25);
            }
            else
            {
                playerValues.increaseScore(100 );
            }
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

    private void Move()
    {
        
    }
}
