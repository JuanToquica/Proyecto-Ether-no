using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Animator animator;
    public Camera playerCamera;
    public float range;
    public float shootTime = 0.5f;
    public float nextFireTime;
    public int gunCapacity = 15;
    public int ammo;

    public ParticleSystem shootVFX;
    public GameObject impactParticles;
    public GameObject bulletHole;


    public void Shoot()
    {      
        if (Time.time>=nextFireTime && ammo>0)
        {
            if (!animator.GetBool ("isOutOfAmmo") && !animator.GetBool("fire")) //Comprueba que no hayan animaciones ejecutandose
            {
                StartAnimation("fire");
                shootVFX.Play();
                AudioManager.instance.PlayClip(AudioManager.instance.shootClip); //Ejecutar sonido de disparo
                nextFireTime = Time.time + shootTime;
                ammo--;
                ConfirmImpact();
            }            
        }
    }

    private void ConfirmImpact()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit impact;


        if (Physics.Raycast(ray, out impact, range, ~0, QueryTriggerInteraction.Ignore)) //Lanza el rayo e ignora los triggers
        {
            Instantiate(impactParticles, impact.point, Quaternion.LookRotation(impact.normal));
            if (impact.transform.CompareTag("Environment"))
            {
                Vector3 offset = impact.normal * 0.01f; //Para que la textura no se laguee
                Instantiate(bulletHole, impact.point + offset, Quaternion.LookRotation(impact.normal));
            }
            if (impact.rigidbody != null && impact.transform.CompareTag("Enemy"))
            {
                Debug.Log("Impacto contra enemigo");
                Enemy enemy = impact.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.ReceiveShoot();
                }
            }
        }
    }

    public void StartAnimation(string animation)
    {
        animator.SetBool(animation, true);
        StartCoroutine(ResetAnimation(animation));
    }

    IEnumerator ResetAnimation(string animation)
    {
        if (animation == "fire")
        {
            yield return new WaitForSeconds(shootTime);
            if (ammo <= 0)
            {
                StartCoroutine(GunReload());
            }
        }
        else if (animation == "isOutOfAmmo")
        {
            yield return new WaitForSeconds(1.5f);
        }
        animator.SetBool(animation, false);
        
    }


    public IEnumerator GunReload()
    {
        if (ammo < gunCapacity && !animator.GetBool("isOutOfAmmo"))
        {   
            StartAnimation("isOutOfAmmo");
            AudioManager.instance.PlayClip(AudioManager.instance.reloadClip);
            yield return new WaitForSeconds(1.51f);
            ammo = gunCapacity;          
        }       
    }
}
