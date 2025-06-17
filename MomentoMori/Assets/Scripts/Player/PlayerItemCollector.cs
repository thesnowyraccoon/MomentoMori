using UnityEngine;

// Title: Pickup Items and Add to Inventory UI - Top Down Unity 2D #10
// Author: Game Code Library
// Date: December 18 2024
// Code version: Unknown
// Availability: https://youtu.be/qQ0ECbgaAKk?si=pp0Of3_Mia8FX6s6

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;

    void Start()
    {
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tarot"))
        {
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                bool itemAdded = inventoryController.AddItem(collision.gameObject);
                SoundEffectManager.Play("Tarot");

                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
