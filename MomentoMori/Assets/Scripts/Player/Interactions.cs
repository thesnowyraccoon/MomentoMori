using UnityEngine;

// Title: How to Interact With Game Objects [Unity Tutorial]
// Author: Comp-3 Interactive 
// Date: April 24 2020
// Code version: Unknown
// Availability: https://youtu.be/GaVADPZlO0o?si=0MwOBmMmnPj6RDBl

[RequireComponent(typeof(BoxCollider2D))] // Interactables require colliders

public abstract class Interactions : MonoBehaviour
{
    // Ensures collider is a trigger for interactions
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Interaction input from player 
    public abstract void Interact();

    // Checks if player is able to interact
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OpenInteractableIcon(); // Displays icon when player can interact
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().CloseInteractableIcon(); // Disables icon when player can no longer interact
        }
    }
}
