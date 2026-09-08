using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 3;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    public float currentHealth=10;
    public float maxHealth=10;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
           OnMonsterDefeated(expReward);
            Destroy(gameObject);
            return;
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }
}