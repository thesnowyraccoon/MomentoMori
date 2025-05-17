using UnityEngine;

public class TarotMenu : MonoBehaviour
{
    // External object references
    PlayerController player;
    Sword sword;
    Insomnium insomnium;

    // Tarot UI
    Canvas tarot;
    UnityEngine.UI.Button t1, t2, t3;

    void Start()
    {
        // Finds external objects
        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();
        sword = player.GetComponentInChildren<Sword>();
        insomnium = GameObject.Find("Insomnium").GetComponent<Insomnium>();

        // Tarot UI and buttons
        tarot = GetComponent<Canvas>();
        t1 = GameObject.Find("T1").GetComponent<UnityEngine.UI.Button>();
        t2 = GameObject.Find("T2").GetComponent<UnityEngine.UI.Button>();
        t3 = GameObject.Find("T3").GetComponent<UnityEngine.UI.Button>();
    }

    // Opens Tarot menu
    public void OpenTarot()
    {
        insomnium.isOpen = true;
        tarot.enabled = true;
    }

    // Closes Tarot menu
    public void CloseTarot()
    {
        insomnium.isOpen = false;
        tarot.enabled = false;
    }

    // Increases player speed
    public void SpeedTarot()
    {
        player.moveSpeed += 5;
        t1.interactable = false;
    }

    // Increases player attack
    public void AttackTarot()
    {
        sword.playerDamage += 5;
        t2.interactable = false;
    }

    // Increases player health
    public void HealthTarot()
    {
        player.maximumHealth = PlayerController.MaximumHealth.Twenty;
        player.HealthGain(10);
        t3.interactable = false;
    }
}
