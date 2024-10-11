using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //Declares items variables
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;

    //Getting item type
    public ItemType itemType;

    //Declaring other script
    InventoryManager inventoryManager;

    void Start()
    {
        //Manually finding InventoryManager script to helpt avoid errors
        inventoryManager = GameObject.Find("UI Manager").GetComponent<InventoryManager>();
    }

    //Adding items to inventory and checking it against a few conditions before destroying the world item
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemType);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                quantity = leftOverItems;
            }
        }
    }
}
