using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelUpgrade : MonoBehaviour
{
    [SerializeField] private EnemyLevel enemyLevel;
    public void Init()
    {
        enemyLevel = GetComponent<EnemyLevel>();
        enemyLevel.OnLevelUp += UpgradeRandomParameter;
    }
    public void SetLevel(int level)
    {
        enemyLevel.ResetLevel();
        enemyLevel.SetLevel(level);
    }

    private void UpgradeRandomParameter()
    {
        byte randomParam = (byte)Random.Range(1, 4);
        switch (randomParam)
        {
            case 1:
                enemyLevel.LevelUpParameter(RPS_System.RPS_Type.Rock);
                return;
            case 2:
                enemyLevel.LevelUpParameter(RPS_System.RPS_Type.Paper);
                return;
            case 3:
                enemyLevel.LevelUpParameter(RPS_System.RPS_Type.Scissors);
                return;

            default:
                Debug.Log("Upgrade Random Parameter Enemy: Неизвестная категория.");
                return;
        }
    }
}
