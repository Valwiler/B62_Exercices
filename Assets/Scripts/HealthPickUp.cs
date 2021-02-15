using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trousseau de vie (PickupBomb)
//     • Un trousseau doit donner un point de vie.
//     • Doit se détruire lorsque ramassé.
//     • Votre joueur ne doit pas pouvoir ramasser un trousseau s’il possède déjà 5 points de vie, soit son maximum de vie.
// 
// 
// 
// 
public class HealthPickUp : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name =="player")
        { 
            other.gameObject.GetComponentInParent<Player>().pickUp("health");
            gameObject.SetActive(false);
        }
     
    }

}
