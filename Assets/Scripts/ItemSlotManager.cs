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
    //This is the item data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    [SerializeField] Sprite EmptySprite;
    public bool isFull;
    [SerializeField] int maxNumberOfItems;

    //This is the item slot itself
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private bool waitForVariable = false;
    public int originSlot;

    string tempItemName;
    int tempQuantity;
    Sprite tempSprite;

    bool conditionMet = false;

    private InventoryManager inventoryManager;


    private void Start()
    {
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite sprite)
    {
        //Checking to see if slot is already full
        if (isFull)
        {
            return quantity;
        }

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
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {

            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
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

    public void OnRightClick()
    {
        if(thisItemSelected)
        {

            tempItemName = itemName;
            tempQuantity = quantity;
            tempSprite = sprite;

            int basicSlot = FindSelectedSlot();
            originSlot = basicSlot;

            inventoryManager.DeselectAllSlots();
            StartItemTransfer();

        }
    }

    public void StartItemTransfer()
    {
        StartCoroutine(WaitForSelectedTrue());
        StartCoroutine(WaitForVaraibleAndTransfer());   
    }

    public IEnumerator WaitForVaraibleAndTransfer()
    {
        // Wait until the waitForVariable becomes true
        while (!waitForVariable)
        {
            yield return null;
        }

        int newSlot = FindSelectedSlot();

        // Transfer item data to the target slot
        TransferItemSlotData(newSlot, tempItemName, tempQuantity, tempSprite);

        // Reset the waitForVariable flag
        waitForVariable = false;
    }

    public IEnumerator WaitForSelectedTrue()
    {
        while (!conditionMet)
        {
            CheckingIfConditionIsTrue();
            yield return null;
        }
        
        waitForVariable = true;
        conditionMet = false;
    }

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
        for (int i = 0; i < inventoryManager.equitmentSlot.Length; i++)
        {
            if (inventoryManager.equitmentSlot[i].thisEquitmentSelected)
            {
                return i;
            }
        }

        // Return -1 or throw an exception if no slot is selected
        return -1;
    }
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
            
            inventoryManager.itemSlot[newSlot].quantityText.text = quantity.ToString();
            EmptyOriginSlot(originSlot);
        }
        
    }
    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = EmptySprite;
    }

    private void EmptyOriginSlot(int originSlot)
    {
        inventoryManager.itemSlot[originSlot].quantityText.enabled = false;
        inventoryManager.itemSlot[originSlot].quantity = 0;
        inventoryManager.itemSlot[originSlot].itemImage.sprite = EmptySprite;
        inventoryManager.itemSlot[originSlot].itemName = null;
    }

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
}