using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    TextMeshPro interactIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactIcon = GetComponentInChildren<TextMeshPro>();
    }
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            interactIcon.enabled = true;   
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            interactIcon.enabled = false;
        }
    }
}
