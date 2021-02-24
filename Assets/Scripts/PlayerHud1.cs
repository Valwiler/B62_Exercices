using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public Text PlayerHealthText;
    public Text PlayerScoreText;
    public Text PlayerBombsText;

    private void Start()
    {
        var player = GameManager.Instance.Player;
        player.Health.OnChanged += OnHealthChanged;
        //player.Bombs.OnChanged += OnBombsChanged;
        //player.Score.OnChanged += OnScoreChanged;

        OnHealthChanged(player.Health);
        //OnBombsChanged(player.Bombs);
        //OnScoreChanged(player.Score);
    }

    private void OnHealthChanged(Health health)
    {
        PlayerHealthText.text = health.Value.ToString();
    }

    //private void OnScoreChanged(Score score)
    //{
    //    //PlayerScoreText.text = score.Value.ToString();
    //}
    //
    //private void OnBombsChanged(Bombs bombs)
    //{
    //    PlayerBombsText.text = "x " + bombs.Value;
    //}
}
