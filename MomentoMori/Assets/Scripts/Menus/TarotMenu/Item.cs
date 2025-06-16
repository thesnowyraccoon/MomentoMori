using System;
using UnityEngine;

// Title: How to Save Items Positions in your Inventory - Top Down Unity 2D #9
// Author: Game Code Library
// Date: December 9 2024
// Code version: Unknown
// Availability: https://youtu.be/Rj98BNumo70?si=p4f-o1RnNXoEC2MB

public class Item : MonoBehaviour
{
    public int ID;

    [HideInInspector] public PlayerController player;
    [HideInInspector] public PlayerAttack attack;
    [HideInInspector] public StaminaUI stamina;

    void Start()
    {
        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();
        attack = GameObject.Find("playerRemy").GetComponent<PlayerAttack>();
        stamina = GameObject.Find("playerRemy").GetComponent<StaminaUI>();
    }

    public virtual void UseItem()
    {
        Debug.Log("Using Item");
        Destroy(gameObject);
    }
}
