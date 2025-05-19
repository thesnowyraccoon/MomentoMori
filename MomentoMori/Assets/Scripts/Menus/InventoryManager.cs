using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Title: Part 1: UI Creation and Game Pause -- Let's Make an Inventory System in Unity
//       Part 4: Item Selection -- Let's Make an Inventory System in Unity
//Author: Night Run Studio
//Date: May 18 2025
//Platform: Youtube
//Code version: Unknown
//Availability: Part 1: https://youtu.be/LaQp5u0_UYk?si=pyCDhHAWnhPOPsve
//              Part 4: https://youtu.be/naDJPTxvgqc?si=dhLu3XtBNuVmCozv

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) 
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false) 
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }


    public void DeselctAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
       
}
