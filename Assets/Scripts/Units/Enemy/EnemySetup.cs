using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetup : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnitHP hP;
    [SerializeField] private EnemyLevelUpgrade levelUpgrade;
    public void Setup()
    {
        hP.Init();
        unit.Init();
        levelUpgrade.Init();
    }
}
