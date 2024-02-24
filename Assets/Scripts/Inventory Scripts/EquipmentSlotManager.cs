using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EquipmentSlotManager : MonoBehaviour, IPointerClickHandler
{
    //Declaring item data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    [SerializeField] Sprite EmptySprite;
    public bool isFull;
    public ItemType itemType;

    //Declaring item slot data
    [SerializeField] private Image itemImage;
    public GameObject selectedShader;
    public bool thisEquipmentSelected;

    //Declaring equipped slot data
    [SerializeField] private EquippedSlotManager Tool1;
    [SerializeField] private EquippedSlotManager Tool2;
    [SerializeField] private EquippedSlotManager Tool3;
    [SerializeField] private EquippedSlotManager Armor;
    [SerializeField] private EquippedSlotManager Potion;
    [SerializeField] private EquippedSlotManager Relic;

    //Referance to InventoryManger script
    private InventoryManager inventoryManager;


    private void Start()
    {
        //Attaching the InventoryManager script from a GameOject to ensure the correct one is assigned and make it easier to for the code to find the script
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
    }

    //Adding an item to an inventory slot while also checking it against a few conditions to ensure the correct mesures are taking so it is assigned correctly
    public int AddItem(string itemName, int quantity, Sprite sprite, ItemType itemType)
    {
        //Checking to see if slot is already full
        if (isFull)
        {
            return quantity;
        }

        //Updating the item type
        this.itemType = itemType;

        //Updating item name
        this.itemName = itemName;

        //Updating item image
        this.sprite = sprite;
        itemImage.sprite = sprite;

        //Updating item quantity
        this.quantity = 1;
        isFull = true;

        return 0;
    }

    //Allowing for the interaction with the inventory slots along with mouse keybinds to call methods that are assigned to the keybinds
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //calls the left click function
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //calls the right click function
            OnRightClick();
        }
    }

    //This will use an item as long as it is usable 
    public void OnLeftClick()
    {
        if (thisEquipmentSelected)
        {
            Equip();
            
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisEquipmentSelected = true;
        }
    }

    private void Equip()
    {
        if (itemType == ItemType.Armor)
        {
            Armor.Equip(sprite, itemName);
        }
        if (itemType == ItemType.Potion)
        {
            Potion.Equip(sprite, itemName);
        }
        if (itemType == ItemType.Relic)
        {
            Relic.Equip(sprite, itemName);
        }
        if (itemType == ItemType.Tool1)
        {
            Tool1.Equip(sprite, itemName);
        }
        if (itemType == ItemType.Tool2)
        {
            Tool2.Equip(sprite, itemName);
        }
        if (itemType == ItemType.Tool3)
        {
            Tool3.Equip(sprite, itemName);
        }

        EmptySlot();

    }

    //This will start the process of moving an item from one slot to another
    public void OnRightClick()
    {

    }
    private void EmptySlot()
    {
        itemImage.sprite = EmptySprite;
        quantity = 0;
        isFull = false;
    }
}
