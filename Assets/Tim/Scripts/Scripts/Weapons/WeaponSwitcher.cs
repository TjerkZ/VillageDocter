using BigRookGames.Weapons;
//using FPSControllerLPFP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    private void Start()
    {
        SetWeapoActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcesKeyInput();
        //ProcesMouseInput();
        if (previousWeapon != currentWeapon)
        {
            SetWeapoActive();
        }

    }

    private void ProcesKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon++;
            if (currentWeapon > transform.childCount - 1)
            {
                currentWeapon = 0; 
            }

        }
    }

    private void ProcesMouseInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
        }
        else
        {
            currentWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
        }
        else
        {
            currentWeapon--;
        }

    }

    private void SetWeapoActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                Debug.Log(weapon.GetChild(0).name);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

}
