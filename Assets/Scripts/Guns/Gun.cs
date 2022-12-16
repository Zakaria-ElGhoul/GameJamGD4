using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public WeaponScriptableObject weaponSO;

    protected string weaponName;

    protected int magazineSize;
    protected int ammoCapacity;
    protected int clips;
    protected int burstSize;

    [HideInInspector] public float damage;
    protected float fireRate;
    protected float reloadTime;
    protected float shotSpeed;

    protected bool isReloading;

    private void Start()
    {
        isReloading = false;
        SetObjReference();
    }

    private void Update()
    {
        if (clips <= 0 && ammoCapacity <= 0)
        {
            return;
        }
        if (ammoCapacity <= 0 && !isReloading || Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }
    }

    public virtual void Shoot()
    {
        if (isReloading)
            return;

        if (clips <= 0 && ammoCapacity <= 0)
        {
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
    public virtual IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        clips--;
        ammoCapacity = magazineSize;
        isReloading = false;
    }

    public virtual IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
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
    public virtual void SetObjReference()
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
