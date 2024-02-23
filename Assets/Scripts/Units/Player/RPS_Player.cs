using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_Player : MonoBehaviour
{
    RPS_System system;
    public void Init()
    {
        system = RPS_System.Instance;
    }

    public void SelectRock()
    {
        SetChoice(RPS_System.RPS_Type.Rock);
    }
    public void SelectPaper()
    {
        SetChoice(RPS_System.RPS_Type.Paper);
    }
    public void SelectScissors()
    {
        SetChoice(RPS_System.RPS_Type.Scissors);
    }
    private void SetChoice(RPS_System.RPS_Type type)
    {
        system.SetChosePlayer(type);
    }
}
