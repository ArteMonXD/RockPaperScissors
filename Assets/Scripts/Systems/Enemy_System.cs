using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_System : MonoBehaviour
{
    [SerializeField] private Unit currentEnemy;
    public Unit CurrentEnemy => currentEnemy;
    public UnitHP EnemyHP => currentEnemy.UnitHP;
    public UnitLevel EnemyLevel => currentEnemy.UnitLevel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
