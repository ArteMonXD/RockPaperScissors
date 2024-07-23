using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationSecondChangeBuff : MonoBehaviour
{
    [SerializeField] private GameObject m_QuestionsPanel;
    
    public void Show()
    {
        m_QuestionsPanel.SetActive(!m_QuestionsPanel.activeSelf);
    }
}
