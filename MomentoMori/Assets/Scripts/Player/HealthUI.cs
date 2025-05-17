using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Title: Player Health System #2: Heart Display UI (Unity Tutorial)
// Author: Night Run Studio
// Date: April 18 2022
// Code version: Unknown
// Availability: https://youtu.be/uqGkNTFzYXM?si=GgB4EGKlyMtqmOPE

public class HealthUI : MonoBehaviour
{
    // Player Stats
    public PlayerController player;

    private int health;
    private int maxHealth;

    // Health UI
    public Sprite emptyStar;
    public Sprite quarterStar;
    public Sprite halfStar;
    public Sprite threequarterStar;
    public Sprite fullStar;
    public Image[] stars;

    void Update()
    {   
        // Gets player health values
        health = player.GetHealth();
        maxHealth = player.GetMaxHealth();

        // Counter for number of health stars based on max health
        int maxCount = 10;

        if (maxHealth == 50)
        {
            maxCount = 5;
        }
        else if (maxHealth == 40)
        {
            maxCount = 4;
        }
        else if (maxHealth == 30)
        {
            maxCount = 3;
        }
        else if (maxHealth == 20)
        {
            maxCount = 2;
        }
        else if (maxHealth == 10)
        {
            maxCount = 1;
        }

        // Loop for checking health values and setting UI elements accordingly
        for (int i = 0; i < stars.Length; i++)
        {
            for (int j = 1; j < maxHealth; j++) // Loop for setting current health values in UI
            {
                if (health < 1)
                {
                    stars[i].sprite = emptyStar;
                }
                else if (health < 5 && health > 0)
                {
                    stars[i].sprite = quarterStar;
                }
                else if (health == 5)
                {
                    stars[i].sprite = halfStar;
                }
                else if (health < 10 && health > 5)
                {
                    stars[i].sprite = threequarterStar;
                }
                else if (health >= 10)
                {
                    stars[i].sprite = fullStar;
                }
            }

            health -= 10; // Subtraction to check each star in current health loop (each star = 10 health)

            if (i < maxCount) // Enables or disables UI based on max health
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }
}
