using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Upgrade")]
public class UpgradeData : ScriptableObject
{
    [SerializeField] public string upgradeName;
    [SerializeField] public float  attackBuff;
    [SerializeField] public float  attackSpeedBuff;
    [SerializeField] public float  healthBuff;
}
