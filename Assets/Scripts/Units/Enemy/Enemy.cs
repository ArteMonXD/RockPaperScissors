using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private EnemySetup enemySetup;
    public EnemySetup EnemySetup => enemySetup;
    [SerializeField] private EnemyLevelUpgrade enemyLevelUpgrade;
    public EnemyLevelUpgrade EnemyLevelUpgrade => enemyLevelUpgrade;
}
