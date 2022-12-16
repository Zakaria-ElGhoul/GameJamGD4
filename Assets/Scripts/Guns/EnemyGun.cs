using System.Collections;
using UnityEngine;

public class EnemyGun : Gun
{

    public override void SetObjReference()
    {
        base.SetObjReference();
    }
    public override void Shoot()
    {
        base.Shoot();
    }
    public override IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
    {
        return base.FireBurst(bulletPrefab, burstSize, rateOfFire);
    }
    public override IEnumerator Reload()
    {
        return base.Reload();
    }
}
