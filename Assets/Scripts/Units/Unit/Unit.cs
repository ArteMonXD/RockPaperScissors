using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitHP))]
public class Unit : MonoBehaviour
{
    private UnitLevel unitLevel;
    public UnitLevel UnitLevel => unitLevel;
    private UnitHP unitHP;
    public UnitHP UnitHP => unitHP;
    private UnitAttack unitAttack;
    public UnitAttack UnitAttack => unitAttack;
    public void Init()
    {
        unitLevel = GetComponent<UnitLevel>();
        unitHP = GetComponent<UnitHP>();
        unitAttack = GetComponent<UnitAttack>();
        unitHP.OnDeath += ReportDeath;
    }

    private void ReportDeath()
    {
        BattleSystem.Instance.EndBattle(this);
        Debug.Log(gameObject.name + " death");
    }
}
