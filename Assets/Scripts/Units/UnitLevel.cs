using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int levelRock = 1;
    public int Rock => levelRock;
    [SerializeField] private int levelPaper = 1;
    public int Paper => levelPaper;
    [SerializeField] private int levelScissors = 1;
    public int Scissors => levelScissors;
    public delegate void LevelUpHandle();
    public event LevelUpHandle OnLevelUp;
    
    public void LevelUp()
    {
        currentLevel++;
        OnLevelUp?.Invoke();
    }
    public void LevelUpParameter(RPS_System.RPS_Type type)
    {
        switch (type)
        {
            case RPS_System.RPS_Type.Rock:
                levelRock++;
                break;
            case RPS_System.RPS_Type.Paper: 
                levelPaper++; 
                break;
            case RPS_System.RPS_Type.Scissors:
                levelScissors++;
                break;
        }
    }
}
