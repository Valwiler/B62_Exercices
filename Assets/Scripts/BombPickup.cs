using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trousseau de bombes (PickupBomb)
//     • Un trousseau doit donner une bombe.
//     • Doit se détruire lorsque ramassé.
//     • Votre joueur ne doit pas pouvoir ramasser un trousseau s’il possède déjà 3 bombes, soit son maximum de bombes.
// 
// 
// 
public class BombPickup : MonoBehaviour
{

    void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "Bomb pickup :" + gameObject.activeSelf );
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name =="player")
        { 
            other.gameObject.GetComponentInParent<Player>().pickUp("bomb");
           gameObject.SetActive(false);
        }
        
    }
    
    
    
}
