using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DeleteTimer = 5;
    public GameObject Explosion;

    public float projectileSpeed = 8f;
    
    
    
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
        if (other.CompareTag("Ennemy"))
        {
            Vector3 impactPoint = transform.position;
            var explosionRotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(Explosion, impactPoint, explosionRotation );
            Destroy(gameObject);
        }
        
    }
}
