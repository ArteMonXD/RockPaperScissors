using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : Singletoon<BattleSystem>
{
    [SerializeField] private Unit player;
    [SerializeField] private Dice_System dice_System;
    [SerializeField] private Enemy_System enemy_System;
    public void Init()
    {
        dice_System = GetComponent<Dice_System>();
        dice_System.OnResultEvent += ApplyingResultBattle;
        enemy_System = GetComponent<Enemy_System>();
    }
    public void EndBattle(Unit.UnitType deathUnit)
    {
        if(deathUnit == Unit.UnitType.Enemy)
        {
            WinBattle();
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //Show Game Over Window
        Debug.Log("Game Over");
    }

    private void WinBattle()
    {
        Debug.Log("Win Battle");
        player.UnitLevel.LevelUp();
    }

    private void ApplyingResultBattle(bool result)
    {
        if (result)
        {
            enemy_System.EnemyHP.Damage();
        }
        else
        {
            player.UnitHP.Damage();
        }
    }
}
