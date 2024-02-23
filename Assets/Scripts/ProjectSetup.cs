using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectSetup : MonoBehaviour
{
    [SerializeField] private Dice_System dice_System;
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private BattleSystem battleSystem;
    void Start()
    {
        dice_System.Init();
        battleSystem.Init();
        playerSetup.Setup();
    }
}
