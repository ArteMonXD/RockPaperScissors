using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class LevelUpgradePanelIndicators : MonoBehaviour
{
    [SerializeField] protected UnitLevel playerLevelData;
    [SerializeField] protected Player_UnitLevelUpgrade playerUpgrader;
    [SerializeField] protected TMP_Text levelRockIndicator;
    [SerializeField] protected TMP_Text levelPaperIndicator;
    [SerializeField] protected TMP_Text levelScissorsIndicator;

    public void Init()
    {
        playerUpgrader = FindObjectOfType<Player_UnitLevelUpgrade>();
        playerLevelData = FindObjectOfType<Player>().UnitLevel;
        playerUpgrader.OnUnitParameterUpgradeEvent += UpdateLevelIndicators;
        UpdateAll();
    }
    public void UpdateLevelIndicators(RPS_System.RPS_Type rPS_Type)
    {
        switch (rPS_Type)
        {
            case RPS_System.RPS_Type.Rock:
                UpdateRockIndicator();
                break;
            case RPS_System.RPS_Type.Paper:
                UpdatePaperIndicator();
                break;
            case RPS_System.RPS_Type.Scissors:
                UpdateScissorsIndicator();
                break;
            default:
                Debug.Log("Method: \"Update Level Indicator\" Передано зyачениe, которое вызвало исключение");
                break;
        }
    }
    protected virtual void UpdateRockIndicator()
    {
        levelRockIndicator.text = "lvl:" + playerLevelData.Rock.ToString();
    }
    protected virtual void UpdatePaperIndicator()
    {
        levelPaperIndicator.text = "lvl:" + playerLevelData.Paper.ToString();
    }
    protected virtual void UpdateScissorsIndicator()
    {
        levelScissorsIndicator.text = "lvl:" + playerLevelData.Scissors.ToString();
    }
    private void UpdateAll()
    {
        UpdateRockIndicator();
        UpdatePaperIndicator();
        UpdateScissorsIndicator();
    }
}
