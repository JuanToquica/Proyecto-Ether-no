using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolilloAttack : MonoBehaviour
{
    public Animator animator;
    public float attackTime;
    public string targetTag;
    public GameObject ParticleSystem;
    private GameObject slash;

    public void Attack()
    {
        if (!animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", true);
            Invoke("ResetAttack", attackTime);
        }       
    }
    public void ResetAttack()
    {
        animator.SetBool("Attack", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag) && animator.GetBool("Attack"))
        {
            Debug.Log($"Golpe a {targetTag}");
        }
    }

    public void ActivateSlash()
    {
        Vector3 pos = transform.position + new Vector3(-0.58f,-0.51f,0.131f);
        Quaternion rot = transform.rotation * Quaternion.Euler(-52.4f,-3f,59.4f);
        slash = GameObject.Instantiate(ParticleSystem,pos,rot);
        Transform weaponTransform = transform.parent;
        slash.transform.SetParent(weaponTransform, true);
        slash.SetActive(false);
    }

    public void ExecuteSlash()
    {
        slash.SetActive(true);
    }

}
