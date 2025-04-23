using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class HealthSysten : MonoBehaviour
{
    public GameObject fullhpPrefab;
    public float health, maxHealth;
    public Slider healthSlider;


    private void Update()
    {
        healthSlider.value = health;
    }
   

}
