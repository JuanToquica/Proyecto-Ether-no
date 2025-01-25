using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float damage = 10f; // Daño que inflige el proyectil
    public float lifeTime = 5f; // Tiempo antes de que el proyectil desaparezca

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruir proyectil después de un tiempo
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detectar si golpea al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            WeaponManager player = collision.gameObject.GetComponent<WeaponManager>();
            if (player != null)
            {
                player.TakeDamage(damage); // Inflige daño al jugador
            }
        }

        // Destruir proyectil tras colisionar
        Destroy(gameObject);
    }
}