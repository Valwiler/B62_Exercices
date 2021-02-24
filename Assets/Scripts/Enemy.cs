using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health Health;
    public GameObject Player;
    public float Speed;
    public Vector3 scale;
    public Player playerValues;

    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        ;
        var rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
    }

    private void Start()
    {
        Player = GameObject.Find("player");
        playerValues = Player.GetComponent<Player>();
        transform.localScale = scale;
        Health = GetComponent<Health>();
    }

    // Update is called once per frame
   // private void Update()
   // {
   //     LookAtPlayer();
   //     transform.position = Vector3.MoveTowards(transform.position,
   //         Player.transform.position,
   //         Speed * Time.deltaTime);
   //     if (Health.Value <= 0)
   //     {
   //         if (Speed > 3)
   //             playerValues.increaseScore(25);
   //         else
   //             playerValues.increaseScore(100);
   //         Destroy(gameObject);
   //     }
   // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectiles")) Health.Value -= 1;
    }

    private void LookAtPlayer()
    {
        var direction = (Vector2) Player.transform.position - (Vector2) transform.position;
        direction.Normalize();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void Move()
    {
    }
}