using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Text healthBarValue;
    private int upperHealthBound=-1;
    private int lowerHealthBound = 0;

    public void setHealth(int healthVal)
    {
        if (healthVal < lowerHealthBound)
        {
            throw new System.ArgumentException("Cannot set health to less than "+lowerHealthBound.ToString());
        } else if (healthVal > upperHealthBound)
        {
            throw new System.ArgumentException("Cannot set health to more than " + upperHealthBound.ToString());
        }
        slider.value = healthVal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        healthBarValue.text = healthVal.ToString() + "%";
    }

    public void setMaxHealth(int health)
    {
        upperHealthBound = health;
        setHealth(health);
    }
}
