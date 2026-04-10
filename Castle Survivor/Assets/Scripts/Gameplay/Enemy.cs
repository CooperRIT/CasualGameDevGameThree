using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 25f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float attack = 4f;

    private Rigidbody2D rb;
    [SerializeField] Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = Player.Instance.transform;
        EnemyManager.Instance.RegisterEnemy(this);
    }

    private void FixedUpdate()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(attack);
            Die();
        }

        if(collision.gameObject.layer == 6)
        {
            TakeDamage(30);
        }
    }
}
