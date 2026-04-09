using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float radius = 10f;

    [SerializeField] private float timer;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            SpawnEnemy();
            timer = 1f / spawnRate;
        }
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)Player.Instance.transform.position +
                           Random.insideUnitCircle.normalized * radius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
