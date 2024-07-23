using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectSetup : MonoBehaviour
{
    [SerializeField] private RPS_System m_RPS_System;
    [SerializeField] private Dice_System dice_System;
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private BattleSystem battleSystem;
    [SerializeField] private Enemy_System enemySystem;
    [SerializeField] private LevelUpgradePanelIndicators levelUpgradePanelIndicators;
    [SerializeField] private LevelUpgradePanelIndicators levelIndicatorsPanel;
    [SerializeField] private BuffPanel buffPanel;

    void Start()
    {
        m_RPS_System.Init();
        dice_System.Init();
        battleSystem.Init();
        enemySystem.Init();
        playerSetup.Setup();
        levelUpgradePanelIndicators.Init();
        levelIndicatorsPanel.Init();
        buffPanel.Init();
    }
}
