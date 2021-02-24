using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DeleteTimer = 5;

    public Player player;
    public float projectileSpeed = 10f;
    public AudioSource Source;
    public AudioClip track;


    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();

        var rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
        player = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position += transform.right * (projectileSpeed * Time.deltaTime);

        DeleteTimer -= Time.deltaTime;

        if (DeleteTimer < 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy") || other.CompareTag("Destructibles"))
        {
           // if (other.CompareTag("Ennemy")) player.increaseScore(25);
            Source.PlayOneShot(track, 0.7f);
            Destroy(gameObject);
        }
    }
}