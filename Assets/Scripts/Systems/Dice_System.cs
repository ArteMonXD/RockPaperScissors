using RPGCharacterAnims.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

[RequireComponent(typeof(RPS_System))]
public class Dice_System : Singletoon<Dice_System>
{
    private RPS_System RPS_System;
    private Enemy_System enemy_System;
    [SerializeField] private Player m_Player;
    [SerializeField] private int stepInfluence = 4;
    public delegate void ResultHandle(int result);
    public event ResultHandle OnResultEvent;
    public void Init()
    {
        RPS_System = GetComponent<RPS_System>();
        m_Player = FindObjectOfType<Player>();
        enemy_System = Enemy_System.Instance; 
        RPS_System.ResultRPSReceivedEvent += VerificationDiceRoll;
    }
    private void VerificationDiceRoll(int advantages)
    {
        int diceRollPlayer = DiceRoll(advantages);
        int diceRollEnemy = DiceRoll(-advantages);
        int bonusPlayer = CalculateBonus(true);
        int bonusEnemy = CalculateBonus(false);
        diceRollPlayer += bonusPlayer;
        diceRollEnemy += bonusEnemy;
        if(diceRollPlayer > diceRollEnemy)
        {
            Debug.Log($"Dice Roll Player: {diceRollPlayer - bonusPlayer}. Bonus Player: {bonusPlayer}. Result Player Roll: {diceRollPlayer}. Dice Roll Enemy: {diceRollEnemy - bonusEnemy}. Bonus Enemy: {bonusEnemy}. Result Enemy Roll: {diceRollEnemy}. Result: Succses");
            OnResultEvent?.Invoke(1);
        }
        else if (diceRollPlayer < diceRollEnemy)
        {
            Debug.Log($"Dice Roll Player: {diceRollPlayer - bonusPlayer}. Bonus Player: {bonusPlayer}. Result Player Roll: {diceRollPlayer}. Dice Roll Enemy: {diceRollEnemy - bonusEnemy}. Bonus Enemy: {bonusEnemy}. Result Enemy Roll: {diceRollEnemy}. Result: Failure");
            OnResultEvent?.Invoke(-1);
        }
        else
        {
            Debug.Log($"Dice Roll Player: {diceRollPlayer - bonusPlayer}. Bonus Player: {bonusPlayer}. Result Player Roll: {diceRollPlayer}. Dice Roll Enemy: {diceRollEnemy - bonusEnemy}. Bonus Enemy: {bonusEnemy}. Result Enemy Roll: {diceRollEnemy}. Result: Draw");
            OnResultEvent?.Invoke(0);
        }
    }
    private int DiceRoll(int advantages)
    {
        int result;
        int diceRollFirst;
        int diceRollSecond;
        switch (advantages)
        {
            case -1:
                diceRollFirst = Random.Range(1, 21);
                diceRollSecond = Random.Range(1, 21);
                result = diceRollFirst < diceRollSecond ? diceRollFirst : diceRollSecond;
                Debug.Log($"Interference: Roll 1: {diceRollFirst} / Roll 2: {diceRollSecond}");
                return result;
            case 0:
                int diceRoll = Random.Range(1, 21);
                Debug.Log($"Equality: Roll: {diceRoll}");
                return diceRoll;
            case 1:
                diceRollFirst = Random.Range(1, 21);
                diceRollSecond = Random.Range(1, 21);
                result = diceRollFirst > diceRollSecond ? diceRollFirst : diceRollSecond;
                Debug.Log($"Advantages: Roll 1: {diceRollFirst} / Roll 2: {diceRollSecond}");
                return result;
            default:
                return 0;
        }
    }
    
    private int CalculateBonus(bool player)
    {
        int bonusValue;
        if (player)
        {
            bonusValue = m_Player.UnitLevel.GetLevelParameter(RPS_System.ChoisePlayer.Value);
        }
        else
        {
            bonusValue = enemy_System.EnemyLevel.GetLevelParameter(RPS_System.ChoiseEnemy.Value);
        }
        float[] array = new float[bonusValue];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1f / (float)(1f + (float)(i / stepInfluence));
        }
        bonusValue = Mathf.FloorToInt(array.Sum());
        return bonusValue;
    }

    //private int FlootToIntConverteUp(float value)
    //{
    //    int result = Mathf.FloorToInt(value);
    //    if (!result.Equals(value))
    //    {
    //        result++;
    //    }
    //    return result;
    //}
}
