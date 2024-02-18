using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject m_Controls_Settings_Panel;
    bool isCSPanelOpen = false;
    public GameObject m_Inventory_Panel;
    bool isInvPanelOpen = false;
    public ItemSlotManager[] itemSlot;

   public void LoadLevel1()
   {
        SceneManager.LoadScene("Level1");
   }

    public void OpenAndCloseSettingsPanel()
    {
        isCSPanelOpen = !isCSPanelOpen;
        m_Controls_Settings_Panel.SetActive(isCSPanelOpen);
    }
    
    public void OpenAndCloseInventoryPanel()
    {
        isInvPanelOpen = !isInvPanelOpen;
        m_Inventory_Panel.SetActive(isInvPanelOpen);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            {
                OpenAndCloseInventoryPanel();
            }
    }

    public void AddItem(string itemName, int quantity, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, sprite);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;   
        }
    }    
}   
