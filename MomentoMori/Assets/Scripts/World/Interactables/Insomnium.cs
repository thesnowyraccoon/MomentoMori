using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]

public class Insomnium : Interactions
{
    [SerializeField] private PlayerController player;

    public bool isOpen = false;

    // Tarot UI
    [SerializeField] private Canvas tarot;

    // Check interaction and animate accordingly
    public override void Interact()
    {
        tarot = GameObject.Find("TarotUI").GetComponent<Canvas>();

        if (isOpen)
        {
            tarot.enabled = false;

            player.moveAction.Enable();
        }
        else
        {
            tarot.enabled = true;

            player.moveAction.Disable();
        }

        isOpen = !isOpen;
    }

    // Assigns sprites and UI and animates or sets state accordingly
    void Start()
    {
        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();
        tarot = GameObject.Find("TarotUI").GetComponent<Canvas>();

        if (tarot != null)
        {
            tarot.enabled = false;
        }
    }
}
