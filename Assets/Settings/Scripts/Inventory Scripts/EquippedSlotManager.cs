using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class EquippedSlotManager : MonoBehaviour, IPointerClickHandler
{
    //Declaring equipped slot data
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotName;
    [SerializeField] private ItemType itemType = new();
    [SerializeField] private Sprite emptySprite;

    public Sprite itemSprite;
    public string itemName;

    private bool slotFull;
    public GameObject selected;
    public bool thisEquipmentSelected;

    //Referance to InventoryManger script
    private InventoryManager inventoryManager;
    private HeldItemManager heldItemManager;

    private void Start()
    {
        //Attaching the InventoryManager script from a GameOject to ensure the correct one is assigned and make it easier to for the code to find the script
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
        heldItemManager = GameObject.Find("character").GetComponent<HeldItemManager>();
    }
    public void Equip(Sprite ItemSprite, string itemName)
    {
        //Automatical emptys the slot to prevent any issues with adding two items to the same slot by accident
        if(slotFull)
        {
            UnEquip();
        }

        //Updating the image
        this.itemSprite = ItemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        //Update the Data
        this.itemName = itemName;
        slotFull = true;

        //Checks what armor and weapons are equipped if any even are
        if (heldItemManager != null)
        {
            heldItemManager.CheckIfToolEquipped();
            heldItemManager.CheckIfArmorEquipped();
        }
    }

    //UnEquipp equipment slot
    public void UnEquip()
    {
        //Deselects all slots
        inventoryManager.DeselectAllSlots();

        inventoryManager.AddItem(itemName, 1, itemSprite, itemType);

        //Updating the slot image for equipped slot
        this.itemName = null;
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;
        
        //Checks if anything is equipped
        heldItemManager.CheckIfToolEquipped();
        heldItemManager.CheckIfArmorEquipped();
    }

    //Allows interaction with the slots through left click
   public void OnPointerClick(PointerEventData eventData)
   {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
   }

    //Calles unEquip slot when selected and slot is already full
    private void OnLeftClick()
    {
        if (thisEquipmentSelected && slotFull)
        {
            UnEquip();
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selected.SetActive(true);
            thisEquipmentSelected = true;
        }
    }
}
