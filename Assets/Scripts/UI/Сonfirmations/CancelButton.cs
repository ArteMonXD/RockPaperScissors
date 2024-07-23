using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : ExecuteButton
{
    [SerializeField] private ConfirmationSecondChangeBuff m_ConfirmationSecondChangeBuff;
    private RPS_System m_RPS_System;
    private void Start()
    {
        m_RPS_System = RPS_System.Instance;
    }
    protected override void Task()
    {
        m_ConfirmationSecondChangeBuff.Show();
        m_RPS_System.SecondChange(false);
    }

    public override void Execute()
    {
        base.Execute();
    }
}
