using UnityEngine;

// Title: How to Interact With Game Objects [Unity Tutorial]
// Author: Comp-3 Interactive 
// Date: April 24 2020
// Code version: Unknown
// Availability: https://youtu.be/GaVADPZlO0o?si=0MwOBmMmnPj6RDBl

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactions : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OpenInteractableIcon();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().CloseInteractableIcon();
        }
    }
}
