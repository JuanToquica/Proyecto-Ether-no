using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healAmount = 20f; // Cantidad de salud que cura

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tiene la etiqueta "Player"
        {
            WeaponManager player = other.GetComponent<WeaponManager>();
            if (player != null)
            {
                player.Heal(healAmount); // Llama al m�todo Heal del jugador
                Destroy(gameObject); // Destruye la poci�n despu�s de usarla
            }
        }
    }
}