using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

 

    public void SetHealth(int health)
    {
        Debug.Log("Setting health");
        slider.value = health;
    }
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }



}
