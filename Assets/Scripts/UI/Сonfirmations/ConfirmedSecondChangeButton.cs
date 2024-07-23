using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmedSecondChangeButton : ExecuteButton
{
    [SerializeField] private ConfirmationSecondChangeBuff m_ConfirmationSecondChangeBuff;
    private RPS_System m_RPS_System;
    void Start()
    {
        m_RPS_System = RPS_System.Instance;
    }
    protected override void Task()
    {
        m_ConfirmationSecondChangeBuff.Show();
        m_RPS_System.SecondChange(true);
    }
    public override void Execute()
    {
        base.Execute();
    }

}
