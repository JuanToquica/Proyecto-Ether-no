using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public Transform player;
    public GunEnemy gunScript;
    public float shootTime;

    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        Vector3 direccion = player.position - transform.position;
        direccion.y = 0;
        transform.rotation = Quaternion.LookRotation(direccion); //El enemigo siempre mira al jugador
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            gunScript.Shoot();
            yield return new WaitForSeconds(shootTime); //Por el momento dispara cada cierto tiempo
        }
    }
}
