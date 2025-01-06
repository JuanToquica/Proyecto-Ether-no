using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Impacto contra enemigo");
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Impacto contra Player");          
        }
        Destroy(gameObject);
    }
}
