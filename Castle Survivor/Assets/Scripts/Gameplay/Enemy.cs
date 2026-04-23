using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 5f;
    private float speed = 1f;
    private float attack = 0.2f;

    private Rigidbody2D rb;
    [SerializeField] Transform target;
    private float knockback = 5.4f;
    private float touchCooldown = 0.3f;
    private float touchTimer;

    private Vector2 knockbackVelocity;
    float knockbackTimer;
    private float knockbackDuration = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 
        target = Player.Instance.transform;
        EnemyManager.Instance.RegisterEnemy(this);

        //grab the scaling rates...
        float speedMultiplier = ScalingManager.Instance.GetSpeedMultiplier();
        float attackMultiplier = ScalingManager.Instance.GetAttackMultiplier();
        float healthMultiplier = ScalingManager.Instance.GetHealthMultiplier();

        //...and apply them to an enemy's stats
        speed *= speedMultiplier;
        attack *= attackMultiplier;
        health *= healthMultiplier;
    }

    private void FixedUpdate()
    {
        touchTimer -= Time.fixedDeltaTime;
        knockbackTimer -= Time.fixedDeltaTime;

        if (knockbackTimer > 0f)
        {
            rb.velocity = knockbackVelocity;
            return;
        }

        Vector2 dir = (target.position - transform.position).normalized;
        rb.velocity = dir * speed;

        float movementSpeed = speed;

        if (touchTimer > 0f)
        {
            movementSpeed *= 0.2f;
        }

        rb.velocity = dir * movementSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        EnemyManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && touchTimer <= 0f)
        {
            Player.Instance.TakeDamage(attack);
            Vector2 knockDirection = (transform.position - target.position).normalized;

            knockbackVelocity = knockDirection * knockback;
            knockbackTimer = knockbackDuration;

            touchTimer = touchCooldown;
        }

        if(collision.gameObject.layer == 6)
        {
            TakeDamage(30);
        }
    }
}
