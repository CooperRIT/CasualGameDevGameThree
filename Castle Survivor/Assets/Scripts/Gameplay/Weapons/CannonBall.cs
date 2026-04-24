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
        Destroy(gameObject, 3f);
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
        Weapon explostion = Instantiate(explosionPrefab, transform.position, Quaternion.identity).GetComponent<Weapon>();

        //This is patchwork at best, but it works for now. 
        explostion.WeaponDamage = weaponDamage;

        explostion.transform.localScale = Vector3.one * (2.5f + (weaponDamage / 20f));

        Destroy(explostion.gameObject, .2f);
    }
}
