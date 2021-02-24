using UnityEngine;

// Trousseau de bombes (PickupBomb)
//     • Un trousseau doit donner une bombe.
//     • Doit se détruire lorsque ramassé.
//     • Votre joueur ne doit pas pouvoir ramasser un trousseau s’il possède déjà 3 bombes, soit son maximum de bombes.
// 
// 
// 
public class BombPickup : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.activeSelf);
        Debug.Log(gameObject.activeInHierarchy);

        ///if (other.gameObject.name == "player")
           // if (other.gameObject.GetComponentInParent<Player>().current_bomb_Count < 3)
           // {
           //     other.gameObject.GetComponentInParent<Player>().pickUp("bomb");
           //     Debug.Log("Nb Bombe : " + other.gameObject.GetComponentInParent<Player>());
           //     Destroy(gameObject);
           // }
    }
}