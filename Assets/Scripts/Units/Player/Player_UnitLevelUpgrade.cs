using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitLevel))]
public class Player_UnitLevelUpgrade : MonoBehaviour
{
    private UnitLevel unitLevel;

    public void Init()
    {
        unitLevel = GetComponent<UnitLevel>();
        unitLevel.OnLevelUp += LevelUpgrade;
    }

    private void LevelUpgrade()
    {
        //Show Upgrade Menu
    }
    public void UpgradeRock()
    {
        unitLevel.LevelUpParameter(RPS_System.RPS_Type.Rock);
    }
    public void UpgradePaper()
    {
        unitLevel.LevelUpParameter(RPS_System.RPS_Type.Paper);
    }
    public void UpgradeScissors()
    {
        unitLevel.LevelUpParameter(RPS_System.RPS_Type.Scissors);
    }
}
