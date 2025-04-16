using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Slider valueSlider;

    public void DisplayMessage()
    {
        messageText.text = "Button Pressed! Welcome to game";
    }

    public void IncreaseSlider()
    {
        valueSlider.value += 1;
    }

    public void DecreaseSlider()
    {
        valueSlider.value -= 1;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
