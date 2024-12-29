using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shootForce = 3000;
    public float range;
    public float shootTime = 0.5f;
    public float nextFireTime;
    public float destroyBulletTime = 2;


    public void Shoot()
    {
        if (Time.time>=nextFireTime)
        {
            GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);
            nextFireTime = Time.time + shootTime;
            Destroy(newBullet, destroyBulletTime);
        }
    }
}
