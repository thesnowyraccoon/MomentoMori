using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Title: Part 3: Fillable Item Slots -- Let's Make an Inventory System in Unity!
//       Part 4: Item Selection -- Let's Make an Inventory System in Unity!
//       Part 5: Item Description -- Let's Make an Inventory System in Unity!
//Author: Night Run Studio
//Date: May 18 2025
//Platform: Youtube
//Code version: Unknown
//Availability: Part 3: https://youtu.be/HInkDgCaf1w?si=YEkB1AOTwbc1dc80
//              Part 4: https://youtu.be/naDJPTxvgqc?si=dhLu3XtBNuVmCozv
//              Part 5: https://youtu.be/GcWN1gZd36E?si=fW71MFUwmx96fN30


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{


    //=====ITEM DATA=====//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;


    //=====ITEM SLOT=====//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;


    //=====ITEM DESCRIPTION SLOT=====//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;


    private void Start()
    {
       inventoryManager = GameObject.Find("Canvas (TarotMenu)").GetComponent<InventoryManager>();
    }


    public void AddItem(string itemname, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemname;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick() 
    {
        inventoryManager.DeselctAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }
    



   public void OnRightClick() 
    {

    }
      

    }
