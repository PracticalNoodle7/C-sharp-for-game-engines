using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour , IPointerClickHandler
{
    //This is the item data
    public string itemName;
    public int quantity;
    public Sprite sprite;
    public bool isFull;
    [SerializeField] int maxNumberOfItems;

    //This is the item slot itself
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

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

    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = sprite;


    }
}
