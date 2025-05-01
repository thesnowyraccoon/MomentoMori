using UnityEngine;

public class TarotMenu : MonoBehaviour
{
    PlayerController player;
    Insomnium insomnium;
    UnityEngine.UI.Button t1, t2, t3;

    void Start()
    {
        player = GameObject.Find("playerRemy").GetComponent<PlayerController>();
        insomnium = GameObject.Find("Insomnium").GetComponent<Insomnium>();
        t1 = GameObject.Find("T1").GetComponent<UnityEngine.UI.Button>();
        t2 = GameObject.Find("T2").GetComponent<UnityEngine.UI.Button>();
        t3 = GameObject.Find("T3").GetComponent<UnityEngine.UI.Button>();
    }

    public void CloseTarot()
    {
        insomnium.isOpen = false;

        Canvas tarot = GameObject.Find("Tarot UI").GetComponent<Canvas>();
        tarot.enabled = false;
    }

    public void SpeedTarot()
    {
        player.moveSpeed += 5;
        t1.interactable = false;
    }

    public void AttackTarot()
    {
        player.playerDamage += 5;
        t2.interactable = false;
    }

    public void HealthTarot()
    {
        player.maxHealth += 50;
        player.playerHealth = player.maxHealth;
        t3.interactable = false;
    }
}
