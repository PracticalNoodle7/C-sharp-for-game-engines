using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public GameObject m_Inventory_Panel;
    bool isInvPanelOpen = false;
    public ItemSlotManager[] itemSlot;
    public EquipableSlotManager[] equitmentSlot;
    public ItemSO[] itemSOs;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenAndCloseInventoryPanel();
        }
    }

    public void OpenAndCloseInventoryPanel()
    {
        isInvPanelOpen = !isInvPanelOpen;
        m_Inventory_Panel.SetActive(isInvPanelOpen);
    }


    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            } 
        }
        return false;
    }


    //When called this method will take the item details and run it though the inventory slots to add it while performing a couple of checks throught
    public int AddItem(string itemName, int quantity, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            //Checks to see if the slot is not full and is the same item as the others in the slot or the slot has no items as all with the quantity of the slot = to 0
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                //checking to see if there are any left over items by defining it here as well
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, sprite);

                //If left over items is greater then 0 then run this loop which will call the method again and add the remaining items to the next avalable slot that meets the requierments
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, sprite);
                }
                    return leftOverItems;
            }
        }
        return quantity;
    }
    //When called it will deselected the all selected inventory slots (Should only ever be one selected at a time so it will run through and deselect all slots)
    public void DeselectAllSlots()
    {
        for (int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;   
        }
    }






























}
