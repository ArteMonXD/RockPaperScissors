using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Enemy_System : Singletoon<Enemy_System>
{
    [SerializeField] private Enemy currentEnemy;
    public Enemy CurrentEnemy => currentEnemy;
    public UnitHP EnemyHP => currentEnemy.UnitHP;
    public UnitLevel EnemyLevel => currentEnemy.UnitLevel;
    public UnitAttack EnemyAttack => currentEnemy.UnitAttack;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int pullEnemy = 5;
    [SerializeField] private List<Enemy> enemys = new List<Enemy>();
    [SerializeField] private int switchCount;
    public delegate void OnEnemySwitch();
    public event OnEnemySwitch OnEnemySwitchEvent;
    public void Init()
    {
        for(int i = 0; i<pullEnemy; i++)
        {
            GameObject c_enemyGO = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, enemyParent);
            Enemy c_enemyUnit = c_enemyGO.GetComponent<Enemy>();
            c_enemyGO.name = "Enemy: " + i;
            enemys.Add(c_enemyUnit);
            if(i == 0)
            {
                currentEnemy = c_enemyUnit;
            }
            c_enemyUnit.EnemySetup.Setup();
        }
        OnEnemySwitchEvent?.Invoke();
        BattleSystem.Instance.OnPlayerWinBattleEvent += SwitchEnemy;
    }
    private void SwitchEnemy()
    {
        Enemy deadEnemy = currentEnemy;
        for(int i = 0; i < enemys.Count; i++)
        {
            if(i != 4)
            {
                enemys[i] = enemys[i + 1];
            }
            else
            {
                enemys[i] = currentEnemy;
            }
        }
        int deadEnemyLevel = deadEnemy.UnitLevel.CurrentLevel;
        Debug.Log(deadEnemy.UnitLevel.CurrentLevel);
        currentEnemy = enemys[0];
        UpgradeEnemy(currentEnemy, deadEnemyLevel + 1);
        OnEnemySwitchEvent?.Invoke();
        if(switchCount == 4)
        {
            foreach(Enemy enemy in enemys)
            {
                enemy.UnitHP.ResetHP();
            }
            switchCount = 0;
        }
        else
        {
            switchCount++;
        }

    }
    private void UpgradeEnemy(Enemy upgradeLevelEnemy, int newLevel)
    {
        upgradeLevelEnemy.EnemyLevelUpgrade.SetLevel(newLevel);
    }
}
