using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingManager : MonoBehaviour
{
    public static ScalingManager Instance;

    [SerializeField] private float timeElapsed;

    [Header("Scale Rates")]
    [SerializeField] private float speedIncreasePerSecond = 0.01f;
    [SerializeField] private float attackIncreasePerSecond = 0.02f;
    [SerializeField] private float healthIncreasePerSecond = 0.04f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    public float GetSpeedMultiplier()
    {
        return 1f + timeElapsed * speedIncreasePerSecond;
    }

    public float GetAttackMultiplier()
    {
        return 1f + timeElapsed * attackIncreasePerSecond;
    }

    public float GetHealthMultiplier()
    {
        return 1f + timeElapsed * healthIncreasePerSecond;
    }
}
