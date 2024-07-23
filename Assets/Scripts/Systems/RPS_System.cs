using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_System : SingletoonBuffHandler<RPS_System>
{
    public enum RPS_Type {Rock, Paper, Scissors, None}
    [SerializeField] private RPS_Type choisePlayer;
    public RPS_Type? ChoisePlayer => choisePlayer;
    [SerializeField] private RPS_Type choiseEnemy;
    public RPS_Type? ChoiseEnemy => choiseEnemy;
    private Enemy_System m_EnemySystem;
    private BattleSystem m_BattleSystem;
    public delegate void ResultRPSReceived(int result);
    public event ResultRPSReceived ResultRPSReceivedEvent;
    public delegate void SecondChangeBuffRequest();
    public event SecondChangeBuffRequest OnSecondChangeBuffRequestEvent;

    public bool m_UseBuff;
    public void Init()
    {
        m_EnemySystem = Enemy_System.Instance;
        m_BattleSystem = BattleSystem.Instance;
        m_EnemySystem.OnEnemySwitchEvent += RandomChoseEnemy;
        m_BattleSystem.OnTakeDamageEvent += RandomChoseEnemy;
    }
    public void SetChosePlayer(RPS_Type type)
    {
        Debug.Log($"Chose Player! Selected {type}");
        choisePlayer = type;
        if (!m_UseBuff)
        {
            CalculateResult();
        }
        else
        {
            OnSecondChangeBuffRequestEvent?.Invoke();
        }
    }

    private void RandomChoseEnemy()
    {
        choiseEnemy = RandomChose();
        Debug.Log($"Chose Enemy! Selected {choiseEnemy}");
    }
    private RPS_Type RandomChose()
    {
        byte randomValue = (byte)Random.Range(0, 3);
        switch (randomValue)
        {
            case 0:
                return RPS_Type.Rock;
            case 1:
                return RPS_Type.Paper;
            case 2:
                return RPS_Type.Scissors;

            default:
                return RPS_Type.None;
        }
    }
    private void RandomChosePlayer()
    {
        choisePlayer = RandomChose();
        Debug.Log($"Chose Player! Selected {choiseEnemy}");
    }
    private void CalculateResult()
    {
        int result = 0;
        if(choisePlayer != choiseEnemy)
        {
            if((choisePlayer == RPS_Type.Rock && choiseEnemy == RPS_Type.Paper) ||
               (choisePlayer == RPS_Type.Paper && choiseEnemy == RPS_Type.Scissors) ||
               (choisePlayer == RPS_Type.Scissors && choiseEnemy == RPS_Type.Rock))
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
    public void SecondChange(bool request)
    {
        if (m_UseBuff)
        {
            if (request)
            {
                RandomChosePlayer();
                CalculateResult();
            }
            else
            {
                CalculateResult();
            }
            m_UseBuff = false;
            BuffUseEvent(4);
        }
    }
    private void OnDestroy()
    {
        m_EnemySystem.OnEnemySwitchEvent -= RandomChoseEnemy;
        m_BattleSystem.OnTakeDamageEvent -= RandomChoseEnemy;
    }

    public void SecondChanceBuff()
    {
        m_UseBuff = true;
    }
}
