using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] Button weaponButton;

    [SerializeField] Image cooldownImage;

    [SerializeField] float cooldown;

    [SerializeField] int weaponIndex;


    public void StartCooldown()
    {
        weaponButton.enabled = false;
        WeaponsManager.instance.onCoolDown[weaponIndex] = true;
        StartCoroutine(nameof(CoolDownMethod));
    }

    IEnumerator CoolDownMethod()
    {
        cooldownImage.fillAmount = 1;
        float counter = 0;
        while(counter < cooldown)
        {
            counter += Time.deltaTime;
            cooldownImage.fillAmount = 1 - counter / cooldown;
            yield return null;
        }

        weaponButton.enabled = true;
        WeaponsManager.instance.onCoolDown[weaponIndex] = false;
    }
}
