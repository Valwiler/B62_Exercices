using UnityEngine;


// Trousseau de vie (PickupBomb)
//     • Un trousseau doit donner un point de vie.
//     • Doit se détruire lorsque ramassé.
//     • Votre joueur ne doit pas pouvoir ramasser un trousseau s’il possède déjà 5 points de vie, soit son maximum de vie.
// 
// 
// 
// 
public class HealthPickUp : MonoBehaviour
{
    public bool isBeingDestroyed;
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void Update()
    {
        if (isBeingDestroyed) return;
    }

    private void OnDestroy()
    {
        isBeingDestroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
            if (other.gameObject.GetComponentInParent<Player>().Health.Value < 5)
            {
                //other.gameObject.GetComponentInParent<Player>().pickUp("health");
                Destroy(gameObject);
            }
    }
}