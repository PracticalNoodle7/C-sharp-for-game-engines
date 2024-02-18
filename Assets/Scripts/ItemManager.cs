using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;

    private MenuManager inventoryManager;



    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("UI Manager").GetComponent<MenuManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }

}
