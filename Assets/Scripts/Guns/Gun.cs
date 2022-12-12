using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public WeaponScriptableObject weaponSO;

    public TMP_Text weaponNameTxt;
    public TMP_Text weaponStatsTxt;

    string weaponName;

    int magazineSize;
    int ammoCapacity;
    int clips;
    int burstSize;
    int totalAmmo;

    public float damage;
    float fireRate;
    float reloadTime;
    float shotSpeed;

    bool isReloading;

    private void Start()
    {
        isReloading = false;
        SetObjReference();
        weaponNameTxt.text = weaponName;
    }
    private void Update()
    {
        if (clips <= 0 && ammoCapacity <= 0)
        {
            weaponStatsTxt.text = "OUT OF AMMO";
            return;
        }
        if (ammoCapacity <= 0 && !isReloading || Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }
        totalAmmo = magazineSize * clips;
        if (!isReloading)
        {
            weaponStatsTxt.text = ammoCapacity.ToString() + " / " + totalAmmo.ToString();
        }
    }

    public void Shoot()
    {
        if (isReloading)
            return;

        if (clips <= 0 && ammoCapacity <= 0)
        {
            weaponStatsTxt.text = "OUT OF AMMO";
            return;
        }

        switch (weaponSO.weaponType)
        {
            case WeaponTypes.SemiAuto:
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
                ammoCapacity--;
                break;
            case WeaponTypes.Automatic:
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
                ammoCapacity--;
                break;
            case WeaponTypes.Burst:
                StartCoroutine(FireBurst(bulletPrefab, burstSize, fireRate));
                break;
            default:
                break;
        }
    }

    #region IEnumerators
    public IEnumerator Reload()
    {
        weaponStatsTxt.text = "Reloading...";
        yield return new WaitForSeconds(reloadTime);
        clips--;
        ammoCapacity = magazineSize;
        isReloading = false;
    }

    public IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
    {
        float bulletDelay = 60 / rateOfFire;
        // rate of fire in weapons is in rounds per minute (RPM), therefore we should calculate how much time passes before firing a new round in the same burst.
        for (int i = 0; i < burstSize; i++)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
            ammoCapacity--;
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    #endregion

    #region Setter
    public void SetObjReference()
    {
        weaponName = weaponSO.weaponName;
        magazineSize = weaponSO.magazineSize;
        ammoCapacity = weaponSO.ammoCapacity;
        clips = weaponSO.clips;
        damage = weaponSO.damage;
        fireRate = weaponSO.fireRate;
        reloadTime = weaponSO.reloadTime;
        shotSpeed = weaponSO.shotSpeed;
        burstSize = weaponSO.burstSize;
    }
    #endregion
}
