using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitLevel : MonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    [SerializeField] protected int levelRock = 1;
    public int Rock => levelRock;
    [SerializeField] protected int levelPaper = 1;
    public int Paper => levelPaper;
    [SerializeField] protected int levelScissors = 1;
    public int Scissors => levelScissors;
    public delegate void LevelUpHandle();
    public event LevelUpHandle OnLevelUp;
    
    protected void LevelUp()
    {
        currentLevel++;
        OnLevelUp?.Invoke();
    }
    public void LevelUpParameter(RPS_System.RPS_Type type)
    {
        if (!CheckResolutionParameterUpgrade())
        {
            return;
        }
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
    private bool CheckResolutionParameterUpgrade()
    {
        int countUpgrade = currentLevel - 1;
        int sumLevelParameters = levelRock + levelPaper + levelScissors;
        int deltaLevelparameters = sumLevelParameters - 3;
        //Debug.Log(countUpgrade + "/" + deltaLevelparameters);
        if (countUpgrade > deltaLevelparameters)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int GetLevelParameter(RPS_System.RPS_Type type)
    {
        switch (type)
        {
            case RPS_System.RPS_Type.Rock:
                return Rock;
            case RPS_System.RPS_Type.Paper:
                return Paper;
            case RPS_System.RPS_Type.Scissors:
                return Scissors;
            default:
                Debug.Log("GetLevelParameter. Не известный тип");
                return -1;
        }
    }
}
