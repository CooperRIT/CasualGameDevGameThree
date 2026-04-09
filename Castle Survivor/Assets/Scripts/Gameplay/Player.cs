using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private float attackMultiplier = 1f;
    [SerializeField] private float attackSpeedMultiplier = 1f;

    private event Action OnDeath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
        Time.timeScale = 0f;
    }

    public void ApplyUpgrade(UpgradeData upgrade)
    {
        attackMultiplier += upgrade.attackBuff;
        attackSpeedMultiplier += upgrade.attackSpeedBuff;
        maxHealth += upgrade.healthBuff;
        currentHealth += upgrade.healthBuff;
    }
}
