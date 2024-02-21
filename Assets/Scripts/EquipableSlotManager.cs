using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipableSlotManager : MonoBehaviour
{
    //This is the item data
    public string equitmentName;
    public int quantity;
    public Sprite sprite;
    public bool isFull;
    [SerializeField] int maxNumberOfItems;

    //This is the item slot itself
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    private InventoryManager inventoryManager;


    private void Start()
    {
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
    }

    public int AddItem(string equitmentName, Sprite sprite)
    {
        //Checking to see if slot is already full
        if (isFull)
        {
            return quantity;
        }

        //Updating item name
        this.equitmentName = equitmentName;

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

}
