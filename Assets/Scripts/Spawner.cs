using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Vaisseau créateur de monstres (Spawner)
//    • Votre vaisseau doit:
//        ◦ Avoir 20 points de vie.
//        ◦ Créer un nouveau monstre à chaque 5 secondes.
//    • Les nouveaux monstres créés par vos vaisseaux doivent:
//        ◦ Avoir le Sprite monstre rouge.
//        ◦ Être deux fois plus rapide qu’un monstre de base.
//        ◦ Avoir une taille (scale) de 0.75 fois celle d’un monstre de base.
//        ◦ Avoir un seul point de vie. 
//Truc: dupliquer le Prefab du monstre vert afin de créer un Prefab différent pour le monstre rouge.
//


public class Spawner : MonoBehaviour
{

    public float spawnCounter = 5;
    public float spawnTimer = 5;
    public Health hp;
    public GameObject[] ListSprite  = new GameObject[2];
    
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Health>();
    }
    void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            int randomMonster = Random.Range(0, 1000)%2;
            var noRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(ListSprite[randomMonster], transform.position, noRotation);
            spawnTimer = spawnCounter;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }

        if (hp.Hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Spawner hit detected");
        if (other.CompareTag("Projectiles"))
        {
            hp.substractHealth();
        }
     
    }
    
}
