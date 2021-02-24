using System;
using UnityEngine;

// Joueur (Player)
//     • Doit avoir 5 points de vie.
//     • Lorsqu’il se fait frapper par un monstre :
//         ◦ Perdre 1 point de vie.
//         ◦ Clignoter (Flash) pendant 2 secondes.
//         ◦ Doit être invincible lorsqu’il clignote et ne pas se faire frapper.
// Truc : utiliser plutôt OnTriggerStay2D(Collider2D collider)afin de pouvoir se faire frapper immédiatement lorsque l’invincibilité se termine.
// 
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Score))]
[RequireComponent(typeof(Bomb))]
[RequireComponent(typeof(Flash))]

public class Player : MonoBehaviour
{
    

    /** Projectile objects and Inner variables  **/
    public Transform BulletSpawnPoint;
    
    
    public Health Health { get; private set; }
    public Bomb Bombs { get; private set; }
    public Score Score{ get; private set; }
    public Flash Flash { get; private set; }
    
    public Bomb Bomb {get; private set;}
   
  
    private const int MAX_BOMB = 3;
    private const int MAX_HP = 5;

    /** Collision, Health and inner variables **/
    public  bool CanBeDamaged { get{return !Flash.enabled;} }
    
    
    public Rigidbody2D body;
    public Collider2D collison;
    

    /** Sound clips **/
    public AudioSource Source;

    public AudioClip ouch;
    public AudioClip pistol;
    public AudioClip Shotgun;

    /** Move variables**/
    public float moveHorizontal;

    public float moveVertical;
    public float runSpeed = 7.0f;

    
    private void Start()
    {
        Health = GetComponent<Health>();
        body = GetComponent<Rigidbody2D>();
        collison = GetComponent<Collider2D>();
      Flash = GetComponent<Flash>();
     // Bomb.CanUse += CanUse;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           
            GameManager.Instance.PrefabManager.Spawn(PrefabManager.Global.Bullet, BulletSpawnPoint.position, transform.rotation);
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Pistol);
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameManager.Instance.PrefabManager.Spawn(PrefabManager.Global.Bullet, BulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 0, 30));
            GameManager.Instance.PrefabManager.Spawn(PrefabManager.Global.Bullet, BulletSpawnPoint.position, transform.rotation);
            GameManager.Instance.PrefabManager.Spawn(PrefabManager.Global.Bullet, BulletSpawnPoint.position, transform.rotation* Quaternion.Euler(0, 0, -30));
            GameManager.Instance.SoundManager.Play(SoundManager.Sfx.Shotgun);
        }

        if (Input.GetButtonDown("Fire3") && Bomb) // Add Condition for bomb count
        {
            Bomb.Value -= 1;
            GameManager.Instance.PrefabManager.Spawn(PrefabManager.Global.Bomb, BulletSpawnPoint.position, transform.rotation);
        }
        
        //if (Health.OnDeath){ Health.OnDeath.Target(this) ;}

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        //transform.position = player.transform.position(0,0, );
        body.velocity = new Vector2(moveHorizontal * runSpeed, moveVertical * runSpeed);
    }

   //
   // private void OnTriggerStay2D(Collider2D other)
   // {
   //     if (other.CompareTag("Ennemy"))
   //         if (InvulnaribilityCounter <= 0)
   //         {
   //             Flash.StartFlash();
   //             Health.Value -= 1;
   //             Source.PlayOneShot(ouch, 0.5f);
   //             InvulnaribilityCounter = InvulnerabiltyFrame;
   //         }
   // }
   //
   // public void increaseScore(int i)
   // {
   //     Score.Value += i;
   // }
   //
   // public void pickUp(string s)
   // {
   //     if (s == "bomb" && current_bomb_Count < MAX_BOMB)
   //         current_bomb_Count += 1;
   //     else if (s == "health" && Health.Value < MAX_HP) Health.Value += 1;
   // }
}