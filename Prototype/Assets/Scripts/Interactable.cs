using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    TextMeshPro interact;

    [HideInInspector] public bool interactable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = GetComponentInChildren<TextMeshPro>();
    }
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            interact.enabled = true;   
            interactable = true; 
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            interact.enabled = false;
            interactable = false;
        }
    }
}
