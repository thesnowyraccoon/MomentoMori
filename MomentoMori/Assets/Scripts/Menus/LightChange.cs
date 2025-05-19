using UnityEngine;
using UnityEngine.UI;

//Title: Changing Brightness of Light Using UI Slider In Unity
//Author: Unity Mechanics
//Date: May 17 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/T2tyoB5iwT8?si=Ag7plUaa1PGXDKAv

public class LightChange : MonoBehaviour
{
    public Slider slider;
    public Light sceneLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = slider.value;
    }
}
