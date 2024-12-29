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
        bolillo.SetActive(true);
        gunAnimator.SetBool("isGunDrawn", false);
        bolilloAnimator.SetBool("isBolilloDrawn", true);
        yield return new WaitForSeconds(gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        currentweapon = Weapon.Bolillo;
        gun.SetActive(false);       
    }

    private IEnumerator HideBolilloAnimation()
    {
        gun.SetActive(true);
        bolilloAnimator.SetBool("isBolilloDrawn", false);
        gunAnimator.SetBool("isGunDrawn", true);
        yield return new WaitForSeconds(bolilloAnimator.GetCurrentAnimatorStateInfo(0).length);
        currentweapon = Weapon.Gun;
        bolillo.SetActive(false);     
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
