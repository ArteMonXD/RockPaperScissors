using TMPro;
using UnityEngine;

public class BuffSlot : ExecuteButton
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private GameObject m_UseNumberIndicator;
    private TMP_Text m_UseNumberIndicatorText;
    [SerializeField] private int m_InventoryLinkIndex;
    public int InventoryLinkIndex => m_InventoryLinkIndex;
    [SerializeField] private PlayerInventory m_PlayerInventory;
    public void SetData(string buffName, int useNumber, int inventoryIndex, PlayerInventory playerInventory)
    {
        m_Text.text = buffName;
        m_InventoryLinkIndex = inventoryIndex;
        if (!m_UseNumberIndicatorText)
        {
            m_UseNumberIndicatorText = m_UseNumberIndicator.GetComponent<TMP_Text>();
        }
        if(useNumber != 0)
        {
            if (!m_UseNumberIndicator.activeSelf)
            {
                m_UseNumberIndicator.SetActive(true);
            }
            m_UseNumberIndicatorText.text = useNumber.ToString();
        }
        else
        {
            if (m_UseNumberIndicator.activeSelf)
            {
                m_UseNumberIndicator.SetActive(false);
            }
        }
        if(m_PlayerInventory == null)
        {
            m_PlayerInventory = playerInventory;
        }  
    }

    protected override void Task()
    {
        m_PlayerInventory.WasteBuff(m_InventoryLinkIndex);
    }
}