using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float attack;

    [SerializeField] private float maxHealth;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAttack;

    [SerializeField] private float exp;
    [SerializeField] private float expThreshold; //basically maxExp, and marks what you need to make it to the next level

    [SerializeField] private int level;


}
