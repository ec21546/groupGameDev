using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float maxHunger = 100f;
    public float hunger = 100f;

    [Header("Stats Increases")]
    public float hungerDepletion = 0.5f;

    [Header("Stats Damages")]
    public float hungerDamage = 1.5f;

    [Header("UI")]
    public StatsBar healthBar;
    public StatsBar hungerBar;

    private bool isGameOver = false;

    private void Start()
    {
        health = maxHealth;
        hunger = maxHunger;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            UpdateStats();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (healthBar != null)
        {
            healthBar.numberText.text = health.ToString("f0");
            healthBar.bar.fillAmount = health / maxHealth;
        }

        if (hungerBar != null)
        {
            hungerBar.numberText.text = hunger.ToString("f0");
            hungerBar.bar.fillAmount = hunger / maxHunger;
        }
    }

    private void UpdateStats()
    {
        if (health <= 0)
        {
            EndGame();
            //return;
            health = 0;
        }

        if (hunger <= 0)
        {
            hunger = 0;
            health -= hungerDamage * Time.deltaTime;
        }

        if (hunger >= maxHunger)
            hunger = maxHunger;

        if (hunger > 0)
            hunger -= hungerDepletion * Time.deltaTime;
    }

    public void EndGame()
    {
        // Implement game over logic here, such as showing a game over screen or restarting the level.
        // For example:
        // GameManager.Instance.GameOver();
        Debug.Log("Game Over");
        //isGameOver = true;
    }
}