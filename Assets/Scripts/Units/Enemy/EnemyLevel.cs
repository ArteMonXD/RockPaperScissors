using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel : UnitLevel
{
    public void ResetLevel()
    {
        currentLevel = 1;
        levelRock = 1;
        levelPaper = 1;
        levelScissors = 1;
    }
    public void SetLevel(int newLevel)
    {
        for(int i = 1; i<newLevel; i++)
        {
            LevelUp();
        }
    }
}
