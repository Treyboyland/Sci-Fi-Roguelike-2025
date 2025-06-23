using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Bullet bulletPrefab;


    bool isReloading;

    float elapsed = 0;

    float reloadTime;

void Update()
{
elapsed += !isReloading ? Time.deltaTime : 0;
reloadTimer = isReloading ? Time.deltaTime : 0;
if(shouldFire && elapsed >= secondsBetweenShots && !isReloading && ammoCount != 0)
{
elapsed = 0;
StartCoroutine(Attack());
}
}

    public override void Fire()
    {

    }

    public override void Fire(bool shouldFire)
    {
        throw new System.NotImplementedException();
    }
}
