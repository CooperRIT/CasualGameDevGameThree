using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float weaponDamage;
    [SerializeField] protected float weaponSpeed;

    public float WeaponDamage
    {
        get { return weaponDamage; }
        set { weaponDamage = value; }
    }

    public abstract void WeaponAction();
}

public class WeaponsManager : MonoBehaviour
{
    public static WeaponsManager instance;

    public List<GameObject> weapons;
    int weaponIndex;

    GameObject currentWeapon;

    [SerializeField] Transform shootPoint;

    public List<bool> onCoolDown;

    [SerializeField] List<ButtonCooldown> cooldowns;

    private void Awake()
    {
        instance = this;
        currentWeapon = weapons[0];
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }


    public void OnClickOfMouse()
    {
        if (onCoolDown[weaponIndex])
        {
            return;
        }

        cooldowns[weaponIndex].StartCooldown();

        GameObject gO = Instantiate(currentWeapon, shootPoint.position, Quaternion.identity);

        gO.transform.right = shootPoint.right;
    }

    public void ChangeWeapon(int index)
    {
        currentWeapon = weapons[index];
        weaponIndex = index;
    }
}
