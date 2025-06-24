using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Bullet bulletPrefab;


    bool isReloading;
    bool isFiring;

    float elapsed = 0;
    float reloadElapsed = 0;

    float reloadTime;
    int ammoCount;
    int maxAmmoCount;

    float secondsBetweenShots;

    void Update()
    {
        elapsed += !isReloading ? Time.deltaTime : 0;
        reloadElapsed += isReloading ? Time.deltaTime : 0;
        if (shouldFire && elapsed >= secondsBetweenShots && !isFiring && !isReloading && ammoCount != 0)
        {
            elapsed = 0;
            Fire();
        }
        if (isReloading && reloadElapsed >= reloadTime)
        {
            isReloading = false;
            ammoCount = maxAmmoCount;
        }
    }

    public override void Fire()
    {

    }

    public override void Fire(bool shouldFire)
    {
        this.shouldFire = shouldFire;
    }
}
