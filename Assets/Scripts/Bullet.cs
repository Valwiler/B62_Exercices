using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DeleteTimer = 5;
    public GameObject Explosion;
    

    public float projectileSpeed = 5f;
    
    void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();

        //Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        //
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.right * (projectileSpeed * Time.deltaTime);
        
        DeleteTimer -= Time.deltaTime;
        
            if (DeleteTimer < 0)
            {
                Destroy(gameObject);
            }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(!other.CompareTag("Player")) 
       { Destroy(gameObject);}
    }
}
