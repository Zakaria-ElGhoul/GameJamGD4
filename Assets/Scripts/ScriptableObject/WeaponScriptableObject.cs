using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GunValues", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{
    public WeaponTypes weaponType;
    public string weaponName;
    public int magazineSize;
    public int ammoCapacity;
    public int clips;
    public int burstSize;
    public float damage;
    public float fireRate;
    public float reloadTime;
    public float shotSpeed;
}