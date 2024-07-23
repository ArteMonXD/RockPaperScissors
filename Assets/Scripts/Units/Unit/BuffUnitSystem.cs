using System.Collections.Generic;
using UnityEngine;


public class BuffUnitSystem : MonoBehaviour
{
    [SerializeField] private List<int> m_CurrentBuffUse = new List<int> {};
    public List<int> CurrentBuffUse => m_CurrentBuffUse;
    [SerializeField] private Buff_Storage m_BuffStorage;
    private Unit m_Unit;
    private RPS_System m_RPS_System;
    private BattleSystem m_BattleSystem;
    private Enemy_System m_EnemySystem;
    private ConfirmationSecondChangeBuff m_ConfirmationSecondChangeBuff;
    public void Init()
    {
        m_Unit = GetComponent<Unit>();
        m_RPS_System = RPS_System.Instance;
        m_BattleSystem = BattleSystem.Instance;
        m_EnemySystem = Enemy_System.Instance;
        m_ConfirmationSecondChangeBuff = FindObjectOfType<ConfirmationSecondChangeBuff>();
        m_Unit.UnitAttack.OnBuffHadlerUseEvent += BuffDisable;
        m_Unit.UnitHP.OnBuffHadlerUseEvent += BuffDisable;
        m_BattleSystem.OnTakeDamageEvent += DisableVisionBuffs;
        m_RPS_System.OnSecondChangeBuffRequestEvent += ChangeTypeRequest;
        m_RPS_System.OnBuffHadlerUseEvent += BuffDisable;
    }
    public void BuffUse(int buffID)
    {
        if(m_CurrentBuffUse.Count != 0)
        {
            if (m_CurrentBuffUse.Contains(buffID))
            {
                return;
            }
        }
        m_CurrentBuffUse.Add(buffID);
        Buff(buffID);
    }
    private void Buff(int buffID)
    {
        BuffData buffData = m_BuffStorage.GetBuffDataForID(buffID);
        switch (buffID)
        {
            case 0:
                m_Unit.UnitAttack.UpDamage(buffData.ConventionalUnits);
                break;
            case 1:
                m_Unit.UnitHP.HealthHP(buffData.ConventionalUnits);
                break;
            case 2:
                if (m_RPS_System.ChoiseEnemy != null)
                {
                    int choseEnemy = (int)m_RPS_System.ChoiseEnemy.Value;
                    int[] tempArray = new int[2];
                    for (int i = 0, j = 0; i < tempArray.Length + 1; i++)
                    {
                        if (i != choseEnemy)
                        {
                            tempArray[j] = i;
                            j++;
                        }
                    }
                    int random = UnityEngine.Random.Range(0, 2);
                    Debug.Log($"Enemy no chose: {(RPS_System.RPS_Type)tempArray[random]}");
                }
                break;
            case 3:
                m_Unit.UnitHP.DefenceReturnable(buffData.ConventionalUnits);
                break;
            case 4:
                m_RPS_System.SecondChanceBuff();
                break;
            case 5:
                ShowLevelEnemy(buffID);
                break;
        }
    }
    private void DisableVisionBuffs()
    {
        if (m_CurrentBuffUse.Contains(2))
        {
            BuffDisable(2);
        }
        if (m_CurrentBuffUse.Contains(5))
        {
            BuffDisable(5);
        }
    }
    private void BuffDisable(int disableID)
    {
        Debug.Log("Disable Buff ID: " + disableID);
        m_CurrentBuffUse.Remove(disableID);
    }

    private void ChangeTypeRequest()
    {
        if(m_ConfirmationSecondChangeBuff == null)
        {
            return;
        }
        m_ConfirmationSecondChangeBuff.Show();
    }

    private void OnDestroy()
    {
        m_Unit.UnitAttack.OnBuffHadlerUseEvent -= BuffDisable;
        m_Unit.UnitHP.OnBuffHadlerUseEvent -= BuffDisable;
        m_BattleSystem.OnTakeDamageEvent -= DisableVisionBuffs;
        m_RPS_System.OnSecondChangeBuffRequestEvent -= ChangeTypeRequest;
        m_RPS_System.OnBuffHadlerUseEvent -= BuffDisable;
    }

    private void ShowLevelEnemy(int buffID)
    {
        int conventionalUnits = m_BuffStorage.GetBuffDataForID(buffID).ConventionalUnits;
        Enemy enemy = m_EnemySystem.CurrentEnemy;
        List<int> ids = new List<int>() { 0, 1, 2};
        int[] currentIDs = new int[conventionalUnits];
        for(int i = 0; i< currentIDs.Length; i++)
        {
            int findId = ids[UnityEngine.Random.Range(0, ids.Count)];
            ids.Remove(findId);
            currentIDs[i] = findId;
        }
        ShowLevelParameters[] levels = new ShowLevelParameters[currentIDs.Length];
        for(int i = 0; i<levels.Length; i++)
        {
            switch (currentIDs[i])
            {
                case 0:
                    levels[i] = new ShowLevelParameters(enemy.UnitLevel.Rock, "Rock");
                    break;
                case 1:
                    levels[i] = new ShowLevelParameters(enemy.UnitLevel.Paper, "Paper");
                    break;
                case 2:
                    levels[i] = new ShowLevelParameters(enemy.UnitLevel.Scissors, "Scissors");
                    break;
            }
            
        }
        Debug.Log($"{levels[0].Name} Parameter Level: {levels[0].Level} / {levels[1].Name} Parameter Level: {levels[1].Level}");
    }
}
public struct ShowLevelParameters
{
    [SerializeField] private int m_Level;
    public int Level => m_Level;
    [SerializeField] private string m_Name;
    public string Name => m_Name;

    public ShowLevelParameters(int values, string name)
    {
        m_Level = values;
        m_Name = name;
    }
} 
