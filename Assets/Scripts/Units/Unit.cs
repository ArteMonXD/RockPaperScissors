using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitLevel))]
public class Unit : MonoBehaviour
{
    public enum UnitType {Player, Enemy }
    [SerializeField] private UnitType type;
    public UnitType Type => type;
    private UnitLevel unitLevel;
    public UnitLevel UnitLevel => unitLevel;
    private UnitHP unitHP;
    public UnitHP UnitHP => unitHP;
    public void Init()
    {
        unitLevel = GetComponent<UnitLevel>();
        unitHP = GetComponent<UnitHP>();
        unitHP.OnDeath += ReportDeath;
    }

    private void ReportDeath()
    {
        BattleSystem.Instance.EndBattle(type);
        Debug.Log(gameObject.name + " death");
    }
}
