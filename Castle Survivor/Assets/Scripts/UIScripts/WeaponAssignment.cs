using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class WeaponAssignment : MonoBehaviour
{
    [SerializeField] Button arrowButton;

    [SerializeField] Button cannonButton;

    //Assigned in inspector
    //id 0 = arrow
    //id 1 = cannon
    public void AssignmWeapon(int weaponID)
    {
        WeaponsManager.instance.ChangeWeapon(weaponID);
    }

    private void Start()
    {
        InputsManager.Instance.inputActions.WeaponSelect.SecondWeapon.performed += SecondWeapon;
        InputsManager.Instance.inputActions.WeaponSelect.FirstWeapon.performed += FirstWeapon;
    }

    public void OnDisable()
    {
        InputsManager.Instance.inputActions.WeaponSelect.SecondWeapon.performed -= SecondWeapon;
        InputsManager.Instance.inputActions.WeaponSelect.FirstWeapon.performed -= FirstWeapon;
    }

    //Time crunch IDC will deal with this later
    void FirstWeapon(InputAction.CallbackContext ctx)
    {
        arrowButton.onClick.Invoke();
    }

    void SecondWeapon(InputAction.CallbackContext ctx)
    {
        cannonButton.onClick.Invoke();
    }
}
