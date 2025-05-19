using UnityEngine;

//Title: Part 2: Collectible Items -- Let's Make an Inventory System in Unity
//       Part 5: Item Description -- Let's Make an Inventory System in Unity!
//Author: Night Run Studio
//Date: May 18 2025
//Platform: Youtube
//Code version: Unknown
//Availability: Part 2: https://youtu.be/e7-EJd5dQgQ?si=c1AcleD1_TIQfgxa
//              Part 5: https://youtu.be/GcWN1gZd36E?si=fW71MFUwmx96fN30


public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       inventoryManager = GameObject.Find("Canvas (TarotMenu)").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }

}
