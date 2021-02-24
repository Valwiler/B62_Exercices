using UnityEngine;

// Bombe (Bomb)
//     • Votre joueur doit commencer avec une bombe.
//         ◦ Avoir jusqu’à 3 bombes maximum.
//     • Le nombre de bombes du joueur doit apparaître à l’écran.
//     • En cliquant sur le bouton milieu de la souris :
//         ◦ Si le joueur ne possède pas de bombes, rien ne doit se passer.
//         ◦ Si le joueur possède au moins une bombe, le joueur doit déposer une bombe à ses pieds.
//     • Une fois déposée, la bombe doit :
//         ◦ Rien faire pendant une seconde.
//         ◦ Clignoter pendant une seconde.
//         ◦ Exploser
//             ▪ Jouer une explosion
//             ▪ Tirer 8 balles
public class Bomb : MonoBehaviour
{
    public delegate void BombEvent(Bomb Bomb);

    // Listeners
    public BombEvent OnChanged;


    public int Initial ;
    public int Max;

    private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            var previous = _value;

            _value = Mathf.Clamp(value, 0, Max);

            if (_value != previous)
            {
                OnChanged?.Invoke(this);
                
            }
        }
    }

    private void Awake()
    {
        Value = Initial;
    }
    
    public bool CanUse
    {
        get { return Value > 0; }
    }
}