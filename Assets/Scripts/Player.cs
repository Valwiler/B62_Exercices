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
    /** Projectile objects and Inner variables  **/
    public GameObject Bullet;
    public GameObject Bomb;
    public Transform BulletSpawnPoint;
    private const int MAX_BOMB = 3;
    public int current_bomb_Count = 0;
    
    
    /** Collision, Health and inner variables **/    
    public float InvulnaribilityCounter = 0;
    public float InvulnerabiltyFrame = 2;
    private const int MAX_HP = 5;
    public int Score = 0;
    public Health hp;
    public Rigidbody2D body;
    public Collider2D collison;
    public Flash flasher;

    /** Sound clips **/
    public AudioSource Source;
    public AudioClip ouch;
    public AudioClip pistol;
    public AudioClip Shotgun;
    
    /** Move variables**/
    public float moveHorizontal ;
    public float moveVertical ;
    public float runSpeed = 7.0f;
   
    private void Start()
    {
        hp = GetComponent<Health>();
        body = GetComponent<Rigidbody2D>();
        collison = GetComponent<Collider2D>();
        flasher = GetComponent<Flash>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            Source.PlayOneShot(pistol,0.5f);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            Source.PlayOneShot(Shotgun,0.5f);
            bulletRotation = transform.rotation * Quaternion.Euler(0, 0, -30);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            Source.PlayOneShot(Shotgun,0.5f);
            bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 30);
            Instantiate(Bullet, BulletSpawnPoint.position, bulletRotation);
            Source.PlayOneShot(Shotgun,0.5f);
        }

        if (Input.GetButtonDown("Fire3") && current_bomb_Count > 0) // Add Condition for bomb count
        {
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Bomb, BulletSpawnPoint.position, bulletRotation);
            current_bomb_Count -= 1;
        }

        if (InvulnaribilityCounter >= 0)
        {
            InvulnaribilityCounter -= Time.deltaTime;
        }

        if (hp.Hp <= 0)
        {
            Destroy(gameObject);
        }
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        //transform.position = player.transform.position(0,0, );
        body.velocity = new Vector2(moveHorizontal * runSpeed, moveVertical * runSpeed);

              
    }

    public void increaseScore(int i)
    {
        Score += i;
    }
    public void pickUp(String s)
    {
        if (s == "bomb" && current_bomb_Count < MAX_BOMB)
        {
            current_bomb_Count += 1;
        }
        else if (s == "health" && hp.Hp < MAX_HP)
        {
            hp.addHealth();
        }
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {

       
        if (other.CompareTag("Ennemy"))
        {
          
            if (InvulnaribilityCounter <= 0)
            {
                flasher.StartFlash();
                hp.substractHealth();
                Source.PlayOneShot(ouch, 0.5f);
                InvulnaribilityCounter = InvulnerabiltyFrame;
                
            }
        }
    }
}
