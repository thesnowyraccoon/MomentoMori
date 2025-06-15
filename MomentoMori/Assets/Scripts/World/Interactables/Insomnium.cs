using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Insomnium : Interactions
{
    [SerializeField] private PlayerController player;

    public bool isOpen = false;

    // Tarot UI
    [SerializeField] private GameObject tarot;

    // Check interaction and animate accordingly
    public override void Interact()
    {
        if (isOpen)
        {
            tarot.SetActive(false);

            player.moveAction.Enable();
        }
        else
        {
            tarot.SetActive(true);

            player.moveAction.Disable();
        }

        isOpen = !isOpen;
    }

    // Assigns sprites and UI and animates or sets state accordingly
    void Start()
    {
        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();

        if (tarot != null)
        {
            tarot.SetActive(false);
        }
    }
}
