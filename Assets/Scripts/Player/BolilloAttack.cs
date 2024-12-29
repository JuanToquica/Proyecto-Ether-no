using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolilloAttack : MonoBehaviour
{
    public Animator animator;
    public float attackTime;

    public void Attack()
    {
        animator.SetBool("Attack", true);
        Invoke("ResetAttack", attackTime);
    }
    public void ResetAttack()
    {
        animator.SetBool("Attack", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || animator.GetBool("Attack"))
        {
            Debug.Log("Golpe a enemigo");
        }
    }
}
