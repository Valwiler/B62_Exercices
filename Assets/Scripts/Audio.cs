using UnityEngine;

// Audio
// Truc: utiliser AudioSource.PlayClipAtPoint pour joueur un AudioClip n’importe où.
//     • Votre jeu doit au lancement du niveau jouer music (10% volume)
//     • Votre jeu doit jouer les sons suivants :
//         ◦ Pistol
//             ▪ Joueur tire avec la souris gauche
//         ◦ Shotgun
//             ▪ Joueur tire avec la souris droite
//         ◦ Hurt
//             ▪ Joueur est blessé par un monstre
//         ◦ Hit
//             ▪ Balle est détruite
//         ◦ Explosion
//             ▪ Baril explose
//             ▪ Bombe explose
//             ▪ Monstre meurt
//             ▪ Vaisseau meurt
//             ▪ Joueur meurt
//         ◦ Spawn
//             ▪ Vaisseau crée un monstre
// 
// Truc: si vous êtes intéressés…
//     • J’ai utilisé le site https://www.bfxr.net/ pour générer les sons.
//     • J’ai utilisé le site https://freemusicarchive.org/ pour trouver la musique sans droits d’auteur (junior85 – Left For Deadish).
public class Audio : MonoBehaviour
{
    public float volume;
    public AudioClip track;
    private AudioSource source;

    private void Start()
    {
        source = new AudioSource();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void play()
    {
        source.PlayOneShot(track, volume);
    }
}