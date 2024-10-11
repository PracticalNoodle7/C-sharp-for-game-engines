using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    //Decalring panel gameobjects and bools to controll if they are open or not
    public GameObject m_Inventory_Canvas;
    bool isInvCanvasOpen = false;

    public GameObject m_InventoryPanel;
    bool isInvPanelOpen = false;

    public GameObject m_EquipmentPanel;
    bool isEquipPanelOpen = false;

    public GameObject m_CraftingPanel;
    bool isCraftingPanelOpen = false;

    public GameObject m_SettingsPanel;
    bool isSettingsPanelOpen = false;

    //Declaring arrays from differnet scripts
    public ItemSlotManager[] itemSlot;
    public ItemSO[] itemSOs;
    public EquipmentSlotManager[] equipmentSlot;
    public EquippedSlotManager[] equippedSlot;

    private void Update()
    {
        //Calls the open/close inventory when I is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenAndCloseInventoryCanvas();
        }
    }

    //Open/closes inventory depending on its current state
    public void OpenAndCloseInventoryCanvas()
    {
        isInvCanvasOpen = !isInvCanvasOpen;
        m_Inventory_Canvas.SetActive(isInvCanvasOpen);

        isInvPanelOpen = !isInvPanelOpen;
        m_InventoryPanel.SetActive(isInvPanelOpen);

    }

    //Open/closes inventory panel depending on its current state
    public void NavigationOpenInventory()
    {
        CloseAllPanels();

        isInvPanelOpen = true;
        m_InventoryPanel.SetActive(isInvPanelOpen);
    }

    //Open/closes Equipment depending on its current state
    public void NavigationOpenEquipment()
    {
        CloseAllPanels();
        isEquipPanelOpen = true;
        m_EquipmentPanel.SetActive(isEquipPanelOpen);

    }

    //Open/closes crafting depending on its current state
    public void NavigationOpenCrafting()
    {
        CloseAllPanels();
        isCraftingPanelOpen = true;
        m_CraftingPanel.SetActive(isCraftingPanelOpen);

    }

    //Open/closes settings depending on its current state
    public void NavigationOpenSettings()
    {   
        CloseAllPanels();
        isSettingsPanelOpen = true;
        m_SettingsPanel.SetActive(isSettingsPanelOpen);

    }

    //closes all pannels when called
    private void CloseAllPanels()
    {
        isInvPanelOpen = false;
        m_InventoryPanel.SetActive(isInvPanelOpen);

        isEquipPanelOpen = false;
        m_EquipmentPanel.SetActive(isEquipPanelOpen);

        isCraftingPanelOpen = false;
        m_CraftingPanel.SetActive(isCraftingPanelOpen);

        isSettingsPanelOpen = false;
        m_SettingsPanel.SetActive(isSettingsPanelOpen);
    }

    // Decides if an item can be used or not
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
    public int AddItem(string itemName, int quantity, Sprite sprite, ItemType itemType)
    {
        if (itemType == ItemType.Consumable || itemType == ItemType.Crafting || itemType == ItemType.None)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                //Checks to see if the slot is not full and is the same item as the others in the slot or the slot has no items as all with the quantity of the slot = to 0
                if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
                {
                    //checking to see if there are any left over items by defining it here as well
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, sprite, itemType);

                    //If left over items is greater then 0 then run this loop which will call the method again and add the remaining items to the next avalable slot that meets the requierments
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, sprite, itemType);
                        
                    }
                    return leftOverItems;
                }
                
            }
            return quantity;
        }
        else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                //Checks to see if the slot is not full and is the same item as the others in the slot or the slot has no items as all with the quantity of the slot = to 0
                if (itemSlot[i].isFull == false && equipmentSlot[i].name == name || equipmentSlot[i].quantity == 0)
                {
                    //checking to see if there are any left over items by defining it here as well
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, sprite, itemType);

                    //If left over items is greater then 0 then run this loop which will call the method again and add the remaining items to the next avalable slot that meets the requierments
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, sprite, itemType);
                        
                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }
    }
    //When called it will deselected the all selected inventory slots (Should only ever be one selected at a time so it will run through and deselect all slots)
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;   
        }

        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisEquipmentSelected = false;
        }

        for (int i = 0; i < equippedSlot.Length; i++)
        {
            equippedSlot[i].selected.SetActive(false);
            equippedSlot[i].thisEquipmentSelected = false;
        }
    }
}

//Declating a enum for different types of items to identify what the item catagory
public enum ItemType { Consumable, Crafting, Potion, Relic, Armor, Tool1, Tool2, Tool3, None, };