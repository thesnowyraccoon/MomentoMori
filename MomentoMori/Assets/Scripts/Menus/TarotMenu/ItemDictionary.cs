using System.Collections.Generic;
using UnityEngine;

// Title: How to Save Items Positions in your Inventory - Top Down Unity 2D #9
// Author: Game Code Library
// Date: December 9 2024
// Code version: Unknown
// Availability: https://youtu.be/Rj98BNumo70?si=p4f-o1RnNXoEC2MB

public class ItemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> itemDictionary;

    void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();

        // Auto Incrementing IDs
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;
            }
        }

        foreach (Item item in itemPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }
    }

    public GameObject GetItemPrefrab(int itemID)
    {
        itemDictionary.TryGetValue(itemID, out GameObject prefab);

        if (prefab == null)
        {
            Debug.LogWarning($"Item {itemID} not found");
        }

        return prefab;
    }
}
