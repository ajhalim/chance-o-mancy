using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Healthbar healthbar = null;

    float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.UpdateHealth(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ScoreKeeper.Instance.GameOver();
    }
}
