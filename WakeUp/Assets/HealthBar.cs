using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth(int MaryHealth)
    {
        slider.maxValue = MaryHealth;
        slider.value = MaryHealth;

        fill.color = gradient.Evaluate(1f);
    }


    public void SetHealth(int MaryHealth)
    {
        slider.value = MaryHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
