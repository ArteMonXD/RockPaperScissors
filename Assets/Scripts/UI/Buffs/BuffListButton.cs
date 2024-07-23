using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BuffListButton : ExecuteButton
{
    [SerializeField] private GameObject m_BuffList;
    public override void Execute()
    {
        base.Execute();
    }
    protected override void Task()
    {
        if (m_BuffList)
        {
            m_BuffList.SetActive(!m_BuffList.activeSelf);
        }
    }
}
