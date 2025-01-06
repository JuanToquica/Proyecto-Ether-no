using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMacheteController : MonoBehaviour
{
    public BolilloAttack macheteScript;
    public Transform player;


    private void Update()
    {
        Vector3 direccion = player.position - transform.position;
        direccion.y = 0;
        transform.rotation = Quaternion.LookRotation(direccion); //El enemigo siempre mira al jugador
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            macheteScript.Attack();
        }
    }
}
