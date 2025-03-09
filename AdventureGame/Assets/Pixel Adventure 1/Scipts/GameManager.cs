using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //need to import TMPro to use things related to it

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public PlayerBehavior player;

    private int score = 0;
    private int playerMaxHealth;

    private void Start()
    {
        playerMaxHealth = player.maxHealth;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealthText()
    {
        healthText.text = "HP: " + player.GetHealth() + "/" + playerMaxHealth;
    }
}
