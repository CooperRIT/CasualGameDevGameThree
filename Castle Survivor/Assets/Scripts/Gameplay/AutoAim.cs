using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] Transform shootPoint;

    void OnFireRate()
    {
        GameObject closestEnemy = EnemyManager.Instance.GetClosestEnemy(transform.position);

        if (closestEnemy != null)
        {
            shootPoint.right = closestEnemy.transform.position - shootPoint.position;
            WeaponsManager.instance.OnClickOfMouse();
        }
    }

    private void Update()
    {
        OnFireRate();
    }
}
