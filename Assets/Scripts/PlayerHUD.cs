using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Player player ;
    public Text PlayerHealthText;

    public Text BombCount;

    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthText.text = player.hp.Hp.ToString();
        BombCount.text = player.current_bomb_Count.ToString();
        Score.text = player.Score.ToString();
    }
}
