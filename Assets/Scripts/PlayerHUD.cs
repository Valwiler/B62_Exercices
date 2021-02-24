using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Text PlayerHealthText;

    public Text BombCount;

    public Text Score;

    private Player player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerHealthText.text = player.Health.Value.ToString();
       // BombCount.text = player.current_bomb_Count.ToString();
        Score.text = player.Score.ToString();
    }
}