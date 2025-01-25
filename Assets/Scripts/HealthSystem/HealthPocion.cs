using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healAmount = 20f; // Cantidad de salud que cura

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene la etiqueta "Player"
        {
            WeaponManager player = other.GetComponent<WeaponManager>();
            if (player != null)
            {
                player.Heal(healAmount); // Llama al método Heal del jugador
                Destroy(gameObject); // Destruye la poción después de usarla
            }
        }
    }
}