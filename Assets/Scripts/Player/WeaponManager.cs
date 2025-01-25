using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float health;
    public float maxHealth;
    // Referencias al HUD
    public WeaponHUDManager weaponHUDManager; // Referencia al HUD Manager
    public Scrollbar healthBar; 
    public Scrollbar staminaBar; 
    public TextMeshProUGUI ammoText; // Cant municion
    public Image gunIcon; // Img pistola
    public Image bolilloIcon; // Img bolillo
    public TextMeshProUGUI activeWeaponText; // Texto arma activa

    private void Update()
    {
        staminaBar.size = stamina / maxStamina;
        healthBar.size = health / maxHealth;
        // Actualizar elementos del HUD seg�n el arma activa
        UpdateWeaponHUD();

        if (isShieldDraw)
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
                stamina += 0.5f * Time.deltaTime;
            }           
        }
    }

    public void ChangeWeapon()
    {
        if (currentweapon == Weapon.Gun){
          StartCoroutine(HideGunAnimation());
          weaponHUDManager.UpdateWeaponHUD(Weapon.Bolillo);
        }
        else { 
            StartCoroutine(HideBolilloAnimation());
            weaponHUDManager.UpdateWeaponHUD(Weapon.Gun);
        }            
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
        if (currentweapon == Weapon.Gun)
        {
            gunScript.Shoot();
        }
        else if (currentweapon == Weapon.Bolillo)
        {
            bolilloScript.Attack();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Municion"))
        {
            gunScript.RecogerMunicion();
            Destroy(other.gameObject);
        }
    }
    private void UpdateWeaponHUD()
    {
        // Muestro que arma est� activa
        if (currentweapon == Weapon.Gun)
        {
            activeWeaponText.text = "Pistola";
            ammoText.text = $"{gunScript.ammo}/{gunScript.gunCapacity}"; // Actualizar munici�n
        }
        else if (currentweapon == Weapon.Bolillo)
        {
            activeWeaponText.text = "Bolillo";
            ammoText.text = "N/A";
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if (!isShieldDraw)
        {
            // Reducir la salud del jugador
            health -= damageAmount;

            if (health < 0)
            {
                health = 0;
                Debug.Log("Jugador muerto");
                // falta crear bien el metodo para que cambie de pantalla y haga todo el show de la muerte
                PlayerDeath();
            }
            UpdateHealthBar();
        }
    }

private void UpdateHealthBar()
{
    // Actualizar el tama�o de la barra de salud
    healthBar.size = health / maxHealth;
}

private void PlayerDeath()
{
    
    Debug.Log("Jugador eliminado. Game Over.");
    // ir a pantalla de inicio o reiniciar el nivel
     SceneManager.LoadScene("MainMenu");
}

    public void Heal(float healAmount)
    {
        health += healAmount;

        if (health > maxHealth)
        {
            health = maxHealth; // Evitar que la salud supere el m�ximo
        }

        UpdateHealthBar(); // Actualiza la barra de salud
        Debug.Log($"Jugador curado: +{healAmount} de salud. Salud actual: {health}");
    }
}
