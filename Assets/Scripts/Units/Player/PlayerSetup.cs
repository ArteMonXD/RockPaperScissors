using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnitHP hP;
    [SerializeField] private RPS_Player RPS_Player;
    [SerializeField] private Player_UnitLevelUpgrade levelUpgrade;
    
    public void Setup()
    {
        unit.Init();
        hP.Init();
        RPS_Player.Init();
        levelUpgrade.Init();
    }
}
