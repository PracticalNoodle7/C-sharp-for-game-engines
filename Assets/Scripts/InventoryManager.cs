using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject m_Inventory_Panel;
    bool isInvPanelOpen = false;
    public ItemSlotManager[] itemSlot;
    public void OpenAndCloseInventoryPanel()
    {
        isInvPanelOpen = !isInvPanelOpen;
        m_Inventory_Panel.SetActive(isInvPanelOpen);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            {
                OpenAndCloseInventoryPanel();
            }
    }
    public int AddItem(string itemName, int quantity, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, sprite);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, sprite);
                    return leftOverItems;
                }
            }
        }

        return quantity;
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
