using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RPS_System))]
public class Dice_System : Singletoon<Dice_System>
{
    RPS_System RPS_System;
    public delegate void ResultHandle(bool result);
    public event ResultHandle OnResultEvent;
    public void Init()
    {
        RPS_System = GetComponent<RPS_System>();
        RPS_System.ResultRPSReceivedEvent += CalculateDifficultyVerification;
    }
    private void CalculateDifficultyVerification(sbyte RPS_result)
    {
        byte difficultyVerification = 0;
        switch (RPS_result)
        {
            case -1:
                difficultyVerification = 15;
                break;
            case 0:
                difficultyVerification = 10;
                break;
            case 1:
                difficultyVerification = 5;
                break;
        }
        VerificationDiceRoll(difficultyVerification);
    }
    private void VerificationDiceRoll(byte difficulty)
    {
        byte diceRoll = (byte)Random.Range(1, 21);
        if(diceRoll >= difficulty)
        {
            Debug.Log($"Dice Roll: {diceRoll}. Difficulty Verification: {difficulty}. Result: Succses");
            OnResultEvent?.Invoke(true);
        }
        else
        {
            Debug.Log($"Dice Roll: {diceRoll}. Difficulty Verification: {difficulty}. Result: Fale");
            OnResultEvent?.Invoke(false);
        }
    }
}
