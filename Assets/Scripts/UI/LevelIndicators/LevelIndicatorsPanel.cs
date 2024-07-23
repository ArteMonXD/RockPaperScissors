using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelIndicatorsPanel : LevelUpgradePanelIndicators
{

    protected override void UpdateRockIndicator()
    {
        levelRockIndicator.text = playerLevelData.Rock.ToString();
    }
    protected override void UpdatePaperIndicator()
    {
        levelPaperIndicator.text = playerLevelData.Paper.ToString();
    }
    protected override void UpdateScissorsIndicator()
    {
        levelScissorsIndicator.text = playerLevelData.Scissors.ToString();
    }
}
