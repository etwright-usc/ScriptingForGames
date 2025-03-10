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
    private int health;
    private int playerMaxHealth;

    private void Start()
    {
        playerMaxHealth = player.maxHealth;
        health = playerMaxHealth;
        UpdateScoreText(0);
    }

    public void UpdateScoreText(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (scoreToAdd != 0)
        {
            if (scoreToAdd > 0)
            {
                scoreText.GetComponent<Animator>().SetTrigger("GoodUpdate");
            }
            else if (scoreToAdd < 0)
            {
                scoreText.GetComponent<Animator>().SetTrigger("BadUpdate");
            }
        }
    }

    public void UpdateHealthText()
    {
        int previousHealth = health;
        health = player.GetHealth();
        healthText.text = "HP: " + player.GetHealth() + "/" + playerMaxHealth;
        if (health != previousHealth)
        {
            if (health > previousHealth)
            {
                healthText.GetComponent<Animator>().SetTrigger("GoodUpdate");
            }
            else if (health < previousHealth)
            {
                healthText.GetComponent<Animator>().SetTrigger("BadUpdate");
            }
        }
    }
}
