using UnityEngine;

// Title: Hotbar with Item Usage and Saving - Unity 2D Top Down #12
// Author: Game Code Library 
// Date: January 7 2025
// Code version: Unknown
// Availability: https://youtu.be/CcfYUYgaBTw?si=QSY_VnB9XXYJT9yI

public class HotBarController : MonoBehaviour
{
    private PlayerController player;

    public GameObject hotBar;
    public GameObject slotPrefab;

    public int slotCount = 3;

    private ItemDictionary itemDictionary;

    void Awake()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();

        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.tarotAction.triggered)
        {
            for (int i = 0; i < slotCount; i++)
            {
                UseItemInSlot(i);
            }
        }
    }

    void UseItemInSlot(int index)
    {
        Slot slot = hotBar.transform.GetChild(index).GetComponent<Slot>();

        if (slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem();
        }
    }
}
