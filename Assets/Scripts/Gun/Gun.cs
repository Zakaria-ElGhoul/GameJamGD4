using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    public WeaponScriptableObject weaponSO;
    string weaponName;
    int magazineSize;
    int ammoCapacity;
    int burstSize;
    float damage;
    float fireRate;
    float reloadTime;
    float shotSpeed;


    private void Start()
    {
        SetObjReference();
    }

    void Update()
    {
    }

    public void Shoot()
    {
        switch (weaponSO.weaponType)
        {
            case WeaponTypes.SemiAuto:
                var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
                break;
            case WeaponTypes.Automatic:
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
                break;
            case WeaponTypes.Burst:
                StartCoroutine(FireBurst(bulletPrefab, burstSize, fireRate));
                break;
            default:
                break;
        }
    }

    public void SetObjReference()
    {
        weaponName = weaponSO.weaponName;
        magazineSize = weaponSO.magazineSize;
        ammoCapacity = weaponSO.ammoCapacity;
        damage = weaponSO.damage;
        fireRate = weaponSO.fireRate;
        reloadTime = weaponSO.reloadTime;
        shotSpeed = weaponSO.shotSpeed;
        burstSize = weaponSO.burstSize;
    }
    public IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
    {
        float bulletDelay = 60 / rateOfFire;
        // rate of fire in weapons is in rounds per minute (RPM), therefore we should calculate how much time passes before firing a new round in the same burst.
        for (int i = 0; i < burstSize; i++)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
