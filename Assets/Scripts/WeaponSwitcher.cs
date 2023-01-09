using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> weapons;
    int currentWeaponIndex;

    void Start()
    {
        currentWeaponIndex = 0;
        SwitchWeapon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Count - 1;
            }
            SwitchWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= weapons.Count)
            {
                currentWeaponIndex = 0;
            }
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == currentWeaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}



