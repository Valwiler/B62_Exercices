using UnityEngine;

// Baril explosif (Barrel)
//     • Votre baril doit :
//         ◦ Lorsqu’il est frappé par une balle et n’est pas déjà amorcé :
//             ▪ Commencer à clignoter.
//             ▪ Exploser après 2 secondes.
//         ◦ Lorsqu’il est frappé par une balle et est déjà amorcé :
//             ▪ Exploser immédiatement.
//     • Lorsque votre baril explose, il doit : 
//         ◦ Jouer une explosion
//         ◦ Tirer 8 balles.

public class Barrel : MonoBehaviour
{
    public GameObject explosion;
    public float aliveCounter = 2;
    public Vector3 centre;
    public Flash flasher;

    public bool wasHitOnce;

    // Update is called once per frame
    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        var rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        flasher = GetComponent<Flash>();
        centre = gameObject.transform.position;
    }

    private void Update()
    {
        UpdateTimer();
        if (aliveCounter <= 0)
        {
            var Rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(explosion, centre, Rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectiles"))
        {
            if (wasHitOnce)
            {
                var Rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
                Instantiate(explosion, centre, Rotation);
                Destroy(gameObject);
            }
            else
            {
                wasHitOnce = true;
                flasher.StartFlash();
            }
        }
    }


    private void UpdateTimer()
    {
        if (wasHitOnce) aliveCounter -= Time.deltaTime;
    }
}