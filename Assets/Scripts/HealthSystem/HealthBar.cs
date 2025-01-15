using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthBar;
    public float maxHealth = 100f;
    public float health;

    private float lerpSpeed = 0.05f;
    void Start()
    {
        health = maxHealth;
        easeHealthBar.value = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (healthSlider.value != easeHealthBar.value)
        {
            easeHealthBar.value = Mathf.Lerp(easeHealthBar.value, health, lerpSpeed);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
