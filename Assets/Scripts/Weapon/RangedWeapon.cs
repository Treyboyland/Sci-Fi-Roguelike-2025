using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Bullet bulletPrefab;


    bool isReloading;

    float elapsed = 0;

    float reloadTime;

    public override void Fire()
    {

    }

    public override void Fire(bool shouldFire)
    {
        throw new System.NotImplementedException();
    }
}
