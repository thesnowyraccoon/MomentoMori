using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Insomnium : Interactions
{
    // Sprite 
    [SerializeField] private Sprite open;
    [SerializeField] private Sprite closed;

    public bool isOpen = false;

    // Tarot UI
    [SerializeField] private GameObject tarot;
    private SpriteRenderer spriteRenderer;

    // Check interaction and animate accordingly
    public override void Interact()
    {
        if (isOpen)
        {
            spriteRenderer.sprite = closed;

            tarot.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = open;

            tarot.SetActive(true);
        }

        isOpen = !isOpen;
    }

    // Assigns sprites and UI and animates or sets state accordingly
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closed;

        tarot = GameObject.Find("Inventory");

        if (tarot != null)
        {
            tarot.SetActive(false);
        }
    }
}
