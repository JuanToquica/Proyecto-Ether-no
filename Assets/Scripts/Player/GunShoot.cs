using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shootForce = 3000;
    public float range;
    public float shootRateTime;


    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shootForce);
    }
}
