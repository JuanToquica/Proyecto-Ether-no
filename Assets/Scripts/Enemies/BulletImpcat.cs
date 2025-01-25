using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpcat : MonoBehaviour
{
    public WeaponManager manager;
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WeaponManager.instance.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
