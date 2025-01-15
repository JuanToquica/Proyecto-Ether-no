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
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        easeHealthBar.value = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
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
