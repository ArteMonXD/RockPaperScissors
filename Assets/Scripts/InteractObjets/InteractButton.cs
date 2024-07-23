using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : ExecuteButton
{
    [SerializeField] RPS_System.RPS_Type m_ButtonType;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private RPS_Player m_RPS_Player;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RPS_Player = FindObjectOfType<RPS_Player>();
    }
    protected override void Task()
    {
        m_Animator.Play(GlobalVar.BUTTON_CLICK_ANIMATION);
        switch (m_ButtonType)
        {
            case RPS_System.RPS_Type.Rock:
                m_RPS_Player.SelectRock();
                break;
            case RPS_System.RPS_Type.Paper:
                m_RPS_Player.SelectPaper();
                break;
            case RPS_System.RPS_Type.Scissors:
                m_RPS_Player.SelectScissors();
                break;
        }
    }

    public override void Execute()
    {
        base.Execute();
    }
}
