using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerGun : Gun
{
    public TMP_Text weaponNameTxt;
    public TMP_Text weaponStatsTxt;

    int totalAmmo;

    private void Start()
    {
        SetObjReference();
        weaponNameTxt.text = weaponName;
        isReloading = false;
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
    public override void SetObjReference()
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
    public override void Shoot()
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
    public override IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
    {
        return base.FireBurst(bulletPrefab, burstSize, rateOfFire);
    }
    public override IEnumerator Reload()
    {
        weaponStatsTxt.text = "Reloading...";
        return base.Reload();
    }
}
