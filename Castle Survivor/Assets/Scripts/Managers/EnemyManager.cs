using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RegisterEnemy(Enemy enemy)
    {
        Debug.Log("Added new enemy");
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public GameObject GetClosestEnemy(Vector3 pos)
    {
        float minDistance = float.MaxValue;
        Enemy closestEnemy = null; 

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(pos, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy?.gameObject;
    }


}
