using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolilloAttack : MonoBehaviour
{
    public Animator animator;
    public float attackTime;
    public string targetTag;
    private GameObject slash;
    public ActivateEffect activateEffect;
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

    public void ExecuteSlash()
    {
        activateEffect.ExecuteSlash();
    }

    public void SlashSound()
    {
        AudioManager.instance.audioSource.volume = 1;
        AudioManager.instance.PlayClip(AudioManager.instance.Bolillaso);
    }
    public void ResetVolume()
    {
        AudioManager.instance.audioSource.volume = 0.4f;
    }
}
