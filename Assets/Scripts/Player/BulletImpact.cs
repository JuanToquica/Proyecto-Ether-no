using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Impacto contra enemigo");
            Destroy(gameObject);
        }
    }
}
