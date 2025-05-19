using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Insomnium : Interactions
{
    [SerializeField] private PlayerController player;

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

            //Time.timeScale = 1f;

            player.moveAction.Enable();
        }
        else
        {
            spriteRenderer.sprite = open;

            tarot.SetActive(true);

            //Time.timeScale = 0f; 

            player.moveAction.Disable();
        }

        isOpen = !isOpen;
    }

    // Assigns sprites and UI and animates or sets state accordingly
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closed;

        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();

        tarot = GameObject.Find("Inventory");

        if (tarot != null)
        {
            tarot.SetActive(false);
        }
    }
}
