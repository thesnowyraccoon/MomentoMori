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

    public Sprite emptyStar;
    public Sprite fullStar;
    public Image[] stars;

    void Update()
    {
        health = player.playerHealth;
        maxHealth = player.maxHealth;

        for (int i = 0; i < stars.Length; i++)
        {
            if (i < health)
            {
                stars[i].sprite = fullStar;
            }
            else
            {
                stars[i].sprite = emptyStar;
            }

            if (i < maxHealth)
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
