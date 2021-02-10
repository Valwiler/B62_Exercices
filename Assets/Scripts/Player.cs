using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Joueur (Player)
//     • Doit avoir 5 points de vie.
//     • Lorsqu’il se fait frapper par un monstre :
//         ◦ Perdre 1 point de vie.
//         ◦ Clignoter (Flash) pendant 2 secondes.
//         ◦ Doit être invincible lorsqu’il clignote et ne pas se faire frapper.
// Truc : utiliser plutôt OnTriggerStay2D(Collider2D collider)afin de pouvoir se faire frapper immédiatement lorsque l’invincibilité se termine.
// 
public class Player : MonoBehaviour
{
    
    public GameObject Bullet;
    public Transform BulletSpawnPoint;
    public float InvulnaribilityCounter = 0;
    public float InvulnerabiltyFrame = 2;
    public Health hp;

    private void Start()
    {
        hp = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            bulletRotation = transform.rotation * Quaternion.Euler(0, 0, -30);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 30);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            
        }

        if (InvulnaribilityCounter > 0)
        {
            InvulnaribilityCounter -= Time.deltaTime;
        }

        if (hp is null)
        {
            Destroy(gameObject);
        }

              
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy"))
        {
            
            
            if (InvulnaribilityCounter == 0)
            {
                hp.substractHealth();
                InvulnaribilityCounter = InvulnerabiltyFrame;
            }
        }
        
    }
}
