using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Insomnium : Interactions
{
    public Sprite open;
    public Sprite closed;
    public bool isOpen;

    private Canvas _tarot;
    private SpriteRenderer spriteRenderer;

    public override void Interact()
    {
        if (isOpen)
        {
            spriteRenderer.sprite = closed;

            _tarot.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = open;

            _tarot.enabled = true;
        }

        isOpen = !isOpen;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closed;

        _tarot = GameObject.Find("Tarot UI").GetComponent<Canvas>();
        _tarot.enabled = false;
    }
}
