using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar; // Referencia al script de la barra de vida
    public float damageAmount = 10f; // Daño recibido por golpe

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            Debug.Log("Enemigo golpeado por el arma");
            healthBar.TakeDamage(damageAmount); // Llama a la función para restar vida
            if (healthBar.health <= 0)
            {
                Die();
            }
        }
    }

    public void ReceiveShoot()
    {
        healthBar.TakeDamage(damageAmount);
        if (healthBar.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo derrotado");
        Destroy(gameObject);
    }

}