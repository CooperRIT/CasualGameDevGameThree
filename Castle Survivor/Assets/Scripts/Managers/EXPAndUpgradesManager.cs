using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
struct UpgradeImages
{
    public Sprite arrowUpgradeImage;
    public Sprite BombUpgradeImage;
}

//Painfully aware of how messy this system is
public class EXPAndUpgradesManager : MonoBehaviour
{
    public static EXPAndUpgradesManager Instance;

    float experience;

    float experienceRequirement = 100;

    int upgradeLevel = 1;

    [SerializeField] Image expBar;

    [SerializeField] List<UpgradeImages> upgrades = new List<UpgradeImages>();

    [SerializeField] UpgradeImages baseImages;

    [SerializeField] Image arrowUIImage;

    [SerializeField] Image bombUIImage;

    private void Awake()
    {
        Instance = this;
    }


    public void IncreaseExperience(float ammountToIncrease)
    {
        experience += ammountToIncrease;

        if (experience > experienceRequirement)
        {
            UpgradePlayer();
        }

        UpdateEXP();
    }

    public void UpgradePlayer()
    {
        experience = 0;
        Debug.Log("Upgrade");
        //This is really funny so we are doing it
        Player.Instance.TakeDamage(-(Player.Instance.MaxHealth - Player.Instance.CurrentHealth));

        if(upgradeLevel < 3)
        {
            WeaponsManager.instance.weapons[0].GetComponent<SpriteRenderer>().sprite = upgrades[upgradeLevel - 1].arrowUpgradeImage;
            WeaponsManager.instance.weapons[1].GetComponent<SpriteRenderer>().sprite = upgrades[upgradeLevel - 1].BombUpgradeImage;
            upgradeLevel++;
        }

        UpgradeDamage();

        experienceRequirement += 50;
        UpdateUI();
    }

    public void UpgradeDamage()
    {
        WeaponsManager.instance.weapons[0].GetComponent<Weapon>().WeaponDamage += 1;
        WeaponsManager.instance.weapons[1].GetComponent<Weapon>().WeaponDamage += 10;
    }

    void UpdateEXP()
    {
        expBar.fillAmount = experience/experienceRequirement;
    }

    //Temp solution, will get this working better in the future
    private void OnApplicationQuit()
    {
        WeaponsManager.instance.weapons[0].GetComponent<SpriteRenderer>().sprite = baseImages.arrowUpgradeImage;
        WeaponsManager.instance.weapons[1].GetComponent<SpriteRenderer>().sprite = baseImages.BombUpgradeImage;

        WeaponsManager.instance.weapons[0].GetComponent<Weapon>().WeaponDamage = 5;
        WeaponsManager.instance.weapons[1].GetComponent<Weapon>().WeaponDamage = 20;


    }

    public void UpdateUI()
    {
        arrowUIImage.sprite = WeaponsManager.instance.weapons[0].GetComponent<SpriteRenderer>().sprite;
        bombUIImage.sprite = WeaponsManager.instance.weapons[1].GetComponent<SpriteRenderer>().sprite;

    }
}
