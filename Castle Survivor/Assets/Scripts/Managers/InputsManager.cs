using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    public static InputsManager Instance;

    public PlayerIAR inputActions;

    public Vector2 mousePosition;

    [SerializeField] Transform shootPoint;


    private void Awake()
    {
        inputActions = new PlayerIAR();
        Instance = this;
    }

    public void Click(InputAction.CallbackContext inputAction)
    {
        Debug.Log("works");
    } 

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.WeaponSelect.FirstWeapon.performed += Click;
    }

    private void OnDisable()
    {
        inputActions.WeaponSelect.FirstWeapon.performed -= Click;
        inputActions?.Disable();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorld.z = 0f; // important for 2D

        shootPoint.right = (mouseWorld - shootPoint.position).normalized;
    }
}
