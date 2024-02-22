using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    //Item data to be collected
    public string itemName;
    public int quantity;
    public Sprite sprite;

    //This is the HotBar slot info
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
    }

    public void AddToHotBar()
    {
        if (inventoryManager.itemSlot[0] != null)
        {
            inventoryManager.itemSlot[0].itemName = this.itemName;
            inventoryManager.itemSlot[0].quantity = this.quantity;
            inventoryManager.itemSlot[0].sprite = this.sprite;

            quantityText.text = this.quantity.ToString();
        }
    }






}
