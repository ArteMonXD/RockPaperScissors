using UnityEngine;

public class LevelUpgradePanel : MonoBehaviour
{
    [SerializeField] private Player_UnitLevelUpgrade playerLevelUpgrade;
    [SerializeField] private LevelUpgradePanelShow levelUpgradePanelShow;

    public void LevelUpRock()
    {
        playerLevelUpgrade.UpgradeParameter(RPS_System.RPS_Type.Rock);
    }
    public void LevelUpPaper()
    {
        playerLevelUpgrade.UpgradeParameter(RPS_System.RPS_Type.Paper);
    }
    public void LevelUpScissors()
    {
        playerLevelUpgrade.UpgradeParameter(RPS_System.RPS_Type.Scissors);
    }
}
