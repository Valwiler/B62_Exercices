using UnityEngine;

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
    public GameObject[] ListSprite = new GameObject[2];
    public Player player;
    public AudioSource source;
    public AudioClip track;
    public AudioClip track2;

    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        var rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }

    // Start is called before the first frame update
    private void Start()
    {
        hp = GetComponent<Health>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (spawnTimer <= 0)
        {
            var randomMonster = Random.Range(0, 1000) % 2;
            var noRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(ListSprite[randomMonster], transform.position, noRotation);
            source.PlayOneShot(track, 0.5f);
            spawnTimer = spawnCounter;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }

        if (hp.Value <= 0)
        {
            //player.increaseScore(500);
            source.PlayOneShot(track2, 0.7f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Projectiles")) hp.substractHealth();
    }
}