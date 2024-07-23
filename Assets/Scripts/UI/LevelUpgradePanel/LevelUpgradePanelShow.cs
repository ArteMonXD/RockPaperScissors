using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelUpgradePanelShow : MonoBehaviour
{
    [SerializeField] private Player_UnitLevelUpgrade playerLevelUpgrade;
    [SerializeField] private GameObject gO_levelUpgradePanel;
    void Start()
    {
        playerLevelUpgrade.OnUnitLevelUpgradeEvent += ShowLevelUpgradePannel;
        playerLevelUpgrade.OnEndUnitLevelUpgradeEvent += CloseWindowLevelUpgradePanel;
    }

    private void ShowLevelUpgradePannel()
    {
        gO_levelUpgradePanel.SetActive(true);
    }

    private void CloseWindowLevelUpgradePanel()
    {
        StartCoroutine(DelayCloseWindow());
    }

    private IEnumerator DelayCloseWindow()
    {
        yield return new WaitForSeconds(0.5f);

        gO_levelUpgradePanel.SetActive(false);
    }
}
