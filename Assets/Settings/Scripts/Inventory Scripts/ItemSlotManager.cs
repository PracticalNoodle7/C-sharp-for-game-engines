using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour, IPointerClickHandler
{
    //Declaring item data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    [SerializeField] Sprite EmptySprite;
    public bool isFull;
    [SerializeField] int maxNumberOfItems;
    public ItemType itemType;

    //Declaring item slot data
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    public GameObject selectedShader;
    public bool thisItemSelected;

    //Declaring information for moving items in the inventory to different slots
    private bool waitForVariable = false; 
    bool conditionMet = false;
    public int originSlot;
    string tempItemName;
    int tempQuantity;
    Sprite tempSprite;

   

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
        this.quantity += quantity;

        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            //return left over items
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Updating quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
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
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);
            if (usable)
            {
                inventoryManager.UseItem(itemName);
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();
            }

            //calls the empty slot methods if the item slot quantity reaches 0 or below (Should never be below 0 but just in case it does we can still call the method)
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }

    //This will start the process of moving an item from one slot to another
    public void OnRightClick()
    {
        if(thisItemSelected)
        {
            //Assigning item data to place holders
            tempItemName = itemName;
            tempQuantity = quantity;
            tempSprite = sprite;

            //Finding the original slot selected and storing the data for later
            int basicSlot = FindSelectedSlot();
            originSlot = basicSlot;

            //Deselecting all slots and starting the transfer item method
            inventoryManager.DeselectAllSlots();
            StartItemTransfer();

        }
    }

    //Starting two coroutines to wait for data to be passed back before continuing with the transfer process
    public void StartItemTransfer()
    {
        StartCoroutine(WaitForSelectedTrue());
        StartCoroutine(WaitForVaraibleAndTransfer());   
    }    
    
    //Checks if a new slot is selected and changes a bool to true when it is
    public void CheckingIfConditionIsTrue()
    {
        for (int i = 0; i < inventoryManager.itemSlot.Length; i++)
        {
            if (inventoryManager.itemSlot[i].thisItemSelected == true)
            {
                conditionMet = !conditionMet;
            }
        }
    }

    //Waits for a new item slot to be selected for transfer of the item
    public IEnumerator WaitForSelectedTrue()
    {
        while (!conditionMet)
        {
            //keeps calling the method till it returs true so it can continue and skip this part of the coroutine
            CheckingIfConditionIsTrue();
            yield return null;
        }
        
        //Sets a bool to true to start the second coroutine and its own bool back to false to avoid any issues of it staying active
        waitForVariable = true;
        conditionMet = false;
    }

    //Collects the location of the new item slot selected so it can transfer the item data to it
    public IEnumerator WaitForVaraibleAndTransfer()
    {
        while (!waitForVariable)
        {
            yield return null;
        }

        //Collects the new slots location for item data transfer
        int newSlot = FindSelectedSlot();

        //passes item datt to the transfer method to move the infromation over to the new slot that has been selected
        TransferItemSlotData(newSlot, tempItemName, tempQuantity, tempSprite);

        //Sets its bool back to false
        waitForVariable = false;
    }


    //Called to find what the selected slot in the item slot array is (if no slot is found it returns -1 to avoid accidently returning the a non selected item slot
    private int FindSelectedSlot()
    {
        for (int i = 0; i < inventoryManager.itemSlot.Length; i++)
        {
            if (inventoryManager.itemSlot[i].thisItemSelected)
            {
                // Found the selected slot
                return i;
            }
        }

        // Return -1 or throw an exception if no slot is selected
        return -1;
    }

    //Trasnfers the item data that is passed through it to the desired slot that is also passed through it
    private void TransferItemSlotData(int newSlot, string tempItemName, int tempQuantity, Sprite tempSprite)
    { 
        if (originSlot != newSlot)
        {
            //Checking to see if slot is already full
            if (!isFull )
            {   
                //Updating item name
                inventoryManager.itemSlot[newSlot].itemName = tempItemName;
                
                //Updating item image
                inventoryManager.itemSlot[newSlot].sprite = tempSprite;
                inventoryManager.itemSlot[newSlot].itemImage.sprite = sprite;

                //Updating quantity text
                inventoryManager.itemSlot[newSlot].quantityText.enabled = true;
                inventoryManager.itemSlot[newSlot].quantity += tempQuantity;
            }
            
            //Sets the quantity text to the amout that quantity is and calles the next method to empty the original item slot
            inventoryManager.itemSlot[newSlot].quantityText.text = quantity.ToString();
            EmptyOriginSlot(originSlot);
        }
        
    }
    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = EmptySprite;
        quantity = 0;
    }

    //resets the original slot back to its defult settings
    private void EmptyOriginSlot(int originSlot)
    {
        inventoryManager.itemSlot[originSlot].quantityText.enabled = false;
        inventoryManager.itemSlot[originSlot].quantity = 0;
        inventoryManager.itemSlot[originSlot].itemImage.sprite = EmptySprite;
        inventoryManager.itemSlot[originSlot].itemName = null;
    }
}