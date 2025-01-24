using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon { Gun, Bolillo, Changing}

public class WeaponManager : MonoBehaviour
{
    public Weapon currentweapon = Weapon.Gun;
    public GameObject gun;
    public GameObject bolillo;
    public GameObject shield;
    public Animator gunAnimator;
    public Animator bolilloAnimator;
    public Animator shieldAnimator;
    public GunShoot gunScript;
    public BolilloAttack bolilloScript;
    public bool isShieldDraw = false;
    public float stamina;
    public float maxStamina;
    public PausarJuego pausarJuego;


    private void Update()
    {
        if(isShieldDraw)
        {
            stamina-= 1f * Time.deltaTime;
            if(stamina < 0)
            {
                StartCoroutine(DrawAndHideShield());
                stamina = 0;
            }
        }
        else
        {
           if (stamina < maxStamina)
           {
                stamina += 1f * Time.deltaTime;
            }           
        }
    }

    public void ChangeWeapon()
    {
        if (currentweapon == Weapon.Gun) StartCoroutine(HideGunAnimation());                 
        else StartCoroutine(HideBolilloAnimation());                
    }

    private IEnumerator HideGunAnimation()
    {
        currentweapon = Weapon.Changing;
        gunAnimator.SetBool("isGunDrawn", false);
        yield return new WaitForSeconds(gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        gun.SetActive(false);
        bolillo.SetActive(true);
        bolilloAnimator.SetBool("isBolilloDrawn", true);
        currentweapon = Weapon.Bolillo;
    }

    private IEnumerator HideBolilloAnimation()
    {
        currentweapon = Weapon.Changing;
        bolilloAnimator.SetBool("isBolilloDrawn", false);
        yield return null; //Espera al siguiente frame para obtener la info de  la animacion que es y no la anterior
        yield return new WaitForSeconds(bolilloAnimator.GetCurrentAnimatorStateInfo(0).length);     
        bolillo.SetActive(false);
        gun.SetActive(true);
        gunAnimator.SetBool("isGunDrawn", true);
        yield return new WaitForSeconds(gunAnimator.GetCurrentAnimatorStateInfo(0).length);
        currentweapon = Weapon.Gun;
    }
    public void Attack()
    {
        if (!pausarJuego.juegoPausado)
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
    
    public void ReloadGun()
    {
        StartCoroutine(gunScript.GunReload());
    }

    public IEnumerator DrawAndHideShield()
    {
        if (!isShieldDraw && stamina > 5)
        {
            shield.SetActive(true);
            shieldAnimator.SetBool("isShieldDraw", true);   
            isShieldDraw = true;
        }
        else if (isShieldDraw)
        {
            shieldAnimator.SetBool("isShieldDraw", false);
            isShieldDraw = false;
            yield return new WaitForSeconds(shieldAnimator.GetCurrentAnimatorStateInfo(0).length);
            shield.SetActive(false);           
        }
             
    }
}
