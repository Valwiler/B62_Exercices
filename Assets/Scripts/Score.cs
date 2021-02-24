using UnityEngine;

// Score
//     • Le score du joueur doit apparaître à l’écran.
//     • Le joueur doit commencer avec 0 points.
//     • Votre joueur doit accumuler des points selon les règles suivantes:
//         ◦ 25 pts: balle frappe n’importe quel monstre ou un vaisseau
//         ◦ 500 pts: vaisseau est vaincu
//         ◦ 100 pts: monstre vert est vaincu
//         ◦ 25 pts: monstre rouge est vaincu
// 
// 
public class Score : MonoBehaviour
{
    public delegate void ScoreEvent(Score score);

    // Listeners
    public ScoreEvent OnChanged;
    public ScoreEvent OnHit;
    public ScoreEvent OnDeath;

    public int Min = 0;

    private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            var previous = _value;

           // _value = Mathf.Clamp(value, 0, Max);

            if (_value != previous)
            {
                OnChanged?.Invoke(this);

                if (_value < previous)
                    OnHit?.Invoke(this);

                if (_value <= 0)
                    OnDeath?.Invoke(this);
            }
        }
    }

    private void Awake()
    {
        Value = Min;
    }
}