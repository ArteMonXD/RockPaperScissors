using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_System : Singletoon<RPS_System>
{
    public enum RPS_Type { Rock, Paper, Scissors}
    [SerializeField] private RPS_Type chosePlayer;
    public RPS_Type ChosePlayer => chosePlayer;
    [SerializeField] private RPS_Type choseEnemy;
    public RPS_Type ChoseEnemy => choseEnemy;
    public delegate void ResultRPSReceived(sbyte result);
    public event ResultRPSReceived ResultRPSReceivedEvent;
    public void SetChosePlayer(RPS_Type type)
    {
        chosePlayer = type;
        RandomChoseEnemy();
    }

    private void RandomChoseEnemy()
    {
        byte randomValue = (byte)Random.Range(0, 3);
        switch (randomValue)
        {
            case 0:
                choseEnemy = RPS_Type.Rock;
                break;
            case 1:
                choseEnemy = RPS_Type.Paper;
                break;
            case 2:
                choseEnemy = RPS_Type.Scissors;
                break;
        }
        CalculateResult();
    }

    private void CalculateResult()
    {
        sbyte result = 0;
        if(chosePlayer != choseEnemy)
        {
            if((chosePlayer == RPS_Type.Rock && choseEnemy == RPS_Type.Paper) ||
               (chosePlayer == RPS_Type.Paper && choseEnemy == RPS_Type.Scissors) ||
               (chosePlayer == RPS_Type.Scissors && choseEnemy == RPS_Type.Rock))
            {
                result = -1;
            }
            else
            {
                result = 1;
            }
        }
        else
        {
            result = 0;
        }

        ResultRPSReceivedEvent?.Invoke(result);
    }
}
