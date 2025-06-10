using UnityEngine;

// Title: Drag and Drop Inventory UI - Top Down Unity 2D #8
// Author: Game Code Library 
// Date: October 7 2024
// Code version: Unknown
// Availability: https://youtu.be/wlBJ0yZOYfM?si=W2ip6xoiSZjbsVKb

public class InventoryController : MonoBehaviour
{
    private ItemDictionary itemDictionary;

    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] tarotPrefabs;

    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();
        
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();

            if (i < tarotPrefabs.Length)
            {
                GameObject tarot = Instantiate(tarotPrefabs[i], slot.transform);
                tarot.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                
                slot.currentItem = tarot;
            }
        }
    }

    public bool AddItem(GameObject itemPrefab)
    {
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();

            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                slot.currentItem = newItem;

                return true;
            }
        }

        Debug.Log("Inventory Full");

        return false;
    }
}
