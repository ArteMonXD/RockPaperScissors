using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerLevel))]
public class Player_UnitLevelUpgrade : MonoBehaviour
{
    private UnitLevel unitLevel;
    public delegate void UnitLevelUpgradeHandler();
    public event UnitLevelUpgradeHandler OnUnitLevelUpgradeEvent;
    public delegate void UnitParameterUpgradeHandler(RPS_System.RPS_Type rPS_Type);
    public event UnitParameterUpgradeHandler OnUnitParameterUpgradeEvent;
    public delegate void EndUnitLevelUpgradeHandler();
    public event EndUnitLevelUpgradeHandler OnEndUnitLevelUpgradeEvent;

    public void Init()
    {
        unitLevel = GetComponent<UnitLevel>();
        unitLevel.OnLevelUp += LevelUpgrade;
    }

    private void LevelUpgrade()
    {
        OnUnitLevelUpgradeEvent?.Invoke();
    }
    public void UpgradeParameter(RPS_System.RPS_Type rPS_Type)
    {
        unitLevel.LevelUpParameter(rPS_Type);
        OnUnitParameterUpgradeEvent?.Invoke(rPS_Type);
        OnEndUnitLevelUpgradeEvent?.Invoke();
    }
}
