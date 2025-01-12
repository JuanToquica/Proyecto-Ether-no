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


    public void Shoot()
    {      
        if (Time.time>=nextFireTime && !animator.GetBool("fire"))
        {
            FireAnimation();
            nextFireTime = Time.time + shootTime;
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit impact;
            
            
            if (Physics.Raycast(ray, out impact, range, ~0, QueryTriggerInteraction.Ignore)) //Lanza el rayo e ignora los triggers
            {
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
    }
    public void FireAnimation()
    {
        animator.SetBool("fire", true);
        Invoke("ResetShoot", shootTime);
    }

    public void ResetShoot()
    {
        animator.SetBool("fire", false);
    }
}
