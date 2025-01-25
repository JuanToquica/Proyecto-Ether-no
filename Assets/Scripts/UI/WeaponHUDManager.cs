using UnityEngine;
using UnityEngine.UI;

public class WeaponHUDManager : MonoBehaviour
{
    public Image centralWeaponIcon; // Imagen central (arma activa)
    public Image cornerWeaponIcon; // Imagen en la esquina superior derecha (arma inactiva)

    public Sprite gunIcon; // Sprite de la pistola
    public Sprite bolilloIcon; // Sprite del bolillo

    private Weapon currentWeapon = Weapon.Gun; // Arma activa

  
    public void UpdateWeaponHUD(Weapon newWeapon)
    {
        currentWeapon = newWeapon;

        if (currentWeapon == Weapon.Gun)
        {
            centralWeaponIcon.sprite = gunIcon; // Colocar pistola en el centro
            cornerWeaponIcon.sprite = bolilloIcon; // Colocar bolillo en la esquina
        }
        else if (currentWeapon == Weapon.Bolillo)
        {
            centralWeaponIcon.sprite = bolilloIcon; // Lo mismo que arriba pero invertido xd
            cornerWeaponIcon.sprite = gunIcon; 
        }
    }
}