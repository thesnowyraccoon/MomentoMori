using UnityEngine;
using UnityEngine.EventSystems;

// Title: Drag and Drop Inventory UI - Top Down Unity 2D #8
// Author: Game Code Library 
// Date: October 7 2024
// Code version: Unknown
// Availability: https://youtu.be/wlBJ0yZOYfM?si=W2ip6xoiSZjbsVKb

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
    GameObject book;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        book = GameObject.Find("Book");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Saves original parent
        transform.SetParent(book.transform.parent);

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.8f; // Makes item semi trans during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // Makes item follow mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f; // Makes item no longer transparent

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); // Checks/Gets slot where item is dropped

        if (dropSlot == null)
        {
            GameObject tarot = eventData.pointerEnter;

            if (tarot != null)
            {
                dropSlot = tarot.GetComponentInParent<Slot>();
            }
        }
       
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if (dropSlot != null)
        {
            if (dropSlot.currentItem != null) // If slot has an item, swap that item with the new item
            {
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                originalSlot.currentItem = null;
            }

            // Moving the item into the new slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else // if no slot under drop then place item back where it came
        {
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
