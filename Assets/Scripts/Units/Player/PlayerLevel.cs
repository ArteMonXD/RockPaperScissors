using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : UnitLevel
{
    private BattleSystem battleSystem;

    public void Init()
    {
        battleSystem = BattleSystem.Instance;
        battleSystem.OnPlayerWinBattleEvent += LevelUp;
    }
}
