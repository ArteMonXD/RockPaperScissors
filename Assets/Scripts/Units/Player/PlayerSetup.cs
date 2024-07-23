using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnitHP hP;
    [SerializeField] private RPS_Player RPS_Player;
    [SerializeField] private Player_UnitLevelUpgrade levelUpgrade;
    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private BuffUnitSystem buffUnitSystem;
    
    public void Setup()
    {
        unit.Init();
        hP.Init();
        playerLevel.Init();
        RPS_Player.Init();
        levelUpgrade.Init();
        playerInventory.Init();
        buffUnitSystem.Init();
    }
}
