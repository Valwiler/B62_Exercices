using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject BalledeGunCriss;
    public float aliveCounter = 1;
    public Vector3 centre;
    public AudioSource source;

    public AudioClip track;

    // Start is called before the first frame update
    private readonly int NB_PROJECTILE = 8;

    private void Start()
    {
        gameObject.transform.SetParent(transform.parent);
        centre = transform.position;
        explode();
    }

    // Update is called once per frame
    private void Update()
    {
        aliveCounter -= Time.deltaTime;
        if (aliveCounter <= 0) Destroy(gameObject);
    }

    private void explode()
    {
        source.PlayOneShot(track, 0.7f);
        float angleRotation = 360 / NB_PROJECTILE;
        float Z = 0;

        for (var i = 0; i < NB_PROJECTILE; i++)
        {
            Debug.Log("Supposé avoir une balle");
            var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, Z);
            Instantiate(BalledeGunCriss, centre, bulletRotation);
            Z += angleRotation;
        }
    }
}