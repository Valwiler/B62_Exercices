using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private int NB_PROJECTILE = 8;
    public GameObject BalledeGunCriss;
    public float aliveCounter = 1;
    public Vector3 centre  ;
    public AudioSource source;
    public AudioClip track;
    
    void Start()
    {
        gameObject.transform.SetParent(transform.parent) ;
        centre = transform.position;
        explode();
    }

    // Update is called once per frame
    void Update()
    {
        aliveCounter -= Time.deltaTime;
        if (aliveCounter <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void explode()
    {
        source.PlayOneShot(track, 0.7f);
        float angleRotation = 360 / NB_PROJECTILE;
        float Z = 0;
        
        for (int i = 0; i < NB_PROJECTILE; i++)
        {
            Debug.Log("Supposé avoir une balle");
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, Z);
            Instantiate(BalledeGunCriss, centre, bulletRotation);
            Z += angleRotation;
        }
    }
}
