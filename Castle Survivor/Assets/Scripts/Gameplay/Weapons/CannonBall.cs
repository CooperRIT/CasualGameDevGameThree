using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Weapon
{
    [SerializeField] GameObject explosionPrefab;
    public override void WeaponAction()
    {
        transform.position += transform.right * weaponSpeed * Time.deltaTime;
    }

    private void Start()
    {
        Destroy(this, 5f);
    }

    private void Update()
    {
        WeaponAction();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObject explostion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(explostion, .5f);
    }
}
