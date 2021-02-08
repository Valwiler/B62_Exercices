using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject Bullet;
    public Transform BulletSpawnPoint;
    public float InvulnaribilityFrame = 0;
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

        if (InvulnaribilityFrame > 0)
        {
            InvulnaribilityFrame -= Time.deltaTime;
        }

        if (hp is null)
        {
            Destroy(gameObject);
        }

              
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            if (InvulnaribilityFrame == 0)
            {
                hp.substractHealth();
                InvulnaribilityFrame = 1;
            }
        }
        
    }
}
