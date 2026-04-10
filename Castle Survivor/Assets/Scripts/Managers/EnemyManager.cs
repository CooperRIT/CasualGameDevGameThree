using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] float enemyEXPAmount = 5f;

    [SerializeField] TextMeshProUGUI enemyKilledText;

    int enemyKilledCount = 0;

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
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        //Send a signal to the EXP manager that u should gain some


        EXPAndUpgradesManager.Instance.IncreaseExperience(enemyEXPAmount);

        //Update Enemy Kileld Count
        enemyKilledCount++;
        enemyKilledText.text = "Enemies Killed: " + enemyKilledCount;
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
