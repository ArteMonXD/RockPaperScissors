using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : Singletoon<BattleSystem>
{
    [SerializeField] private Unit player;
    [SerializeField] private Dice_System dice_System;
    [SerializeField] private Enemy_System enemy_System;
    public delegate void PlayerWinBattle();
    public event PlayerWinBattle OnPlayerWinBattleEvent;
    public delegate void TakeDamage();
    public event TakeDamage OnTakeDamageEvent;


    public void Init()
    {
        dice_System = GetComponent<Dice_System>();
        dice_System.OnResultEvent += ApplyingResultBattle;
        enemy_System = GetComponent<Enemy_System>();
    }
    public void EndBattle(Unit unit)
    {
        if(unit as Enemy)
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
        //player.UnitLevel.LevelUp();
        OnPlayerWinBattleEvent?.Invoke();
    }

    private void ApplyingResultBattle(int result)
    {
        switch (result)
        {
            case -1:
                player.UnitHP.Damage(enemy_System.EnemyAttack.GetDamageValue(), enemy_System.CurrentEnemy);
                break;
            case 0:
                player.UnitHP.Damage(enemy_System.EnemyAttack.GetDamageValue(), enemy_System.CurrentEnemy);
                enemy_System.EnemyHP.Damage(player.UnitAttack.GetDamageValue(), player);
                break;
            case 1:
                enemy_System.EnemyHP.Damage(player.UnitAttack.GetDamageValue(), player);
                break;
        }
        OnTakeDamageEvent?.Invoke();
        //if (result)
        //{
        //    enemy_System.EnemyHP.Damage();
        //}
        //else
        //{
        //    player.UnitHP.Damage();
        //}
    }
}
