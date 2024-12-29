using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon { Gun, Bolillo }

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    

    public Weapon currentweapon = Weapon.Gun;
    public GameObject gun;
    public GameObject bolillo;
    public GameObject shield;
    public Animator gunAnimator;
    public Animator bolilloAnimator;
    public GunShoot gunScript;
    public BolilloAttack bolilloScript;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeWeapon()
    {
        if (currentweapon == Weapon.Gun) StartCoroutine(HideGunAnimation());                 
        else StartCoroutine(HideBolilloAnimation());                
    }

    private IEnumerator HideGunAnimation()
    {
        currentweapon = Weapon.Bolillo;
        gunAnimator.SetBool("isGunDrawn", false);
        yield return new WaitForSeconds(gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("gun: "+ gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        gun.SetActive(false);
        bolillo.SetActive(true);
        bolilloAnimator.SetBool("isBolilloDrawn", true);
    }

    private IEnumerator HideBolilloAnimation()
    {
        currentweapon = Weapon.Gun;
        bolilloAnimator.SetBool("isBolilloDrawn", false);
        yield return new WaitForSeconds(bolilloAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("bolillo: "+ bolilloAnimator.GetCurrentAnimatorStateInfo(0).length);
        bolillo.SetActive(false);
        gun.SetActive(true);
        gunAnimator.SetBool("isGunDrawn", true);
    }
    public void Attack()
    {
        if (currentweapon == Weapon.Gun)
        {
            gunScript.Shoot();
        }
        else if (currentweapon == Weapon.Bolillo)
        {
            bolilloScript.Attack();
        }
    }
}
