using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    public override void WeaponAction()
    {
        transform.position += transform.right * weaponSpeed * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponAction();
    }
}
