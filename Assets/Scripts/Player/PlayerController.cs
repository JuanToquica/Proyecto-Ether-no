using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WeaponManager.instance.ChangeWeapon();
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            WeaponManager.instance.Attack();
        }
    }
}
