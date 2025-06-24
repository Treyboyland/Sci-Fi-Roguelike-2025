using System.Collections;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    Collider2D weaponCollider;

    bool isFiring;
    float elapsed;

    float thrustTime;
    float stayTime;
    float distance;

    float secondsBetweenShots;

    IEnumerator Attack()
    {
        var startPos = transform.localPosition;

        var endPos = transform.forward * distance;
        isFiring = true;

        float elapsedThrust = 0;
        //Weapon will stay in space, and then come back
        while (elapsedThrust < thrustTime)
        {
            elapsedThrust += Time.deltaTime;
            var newPos = Vector3.Lerp(startPos, startPos + endPos, elapsedThrust / thrustTime);
            transform.localPosition = newPos;
            yield return null;
        }

        yield return new WaitForSeconds(stayTime);
        elapsedThrust = 0;
        while (elapsedThrust < thrustTime)
        {
            elapsedThrust += Time.deltaTime;
            var newPos = Vector3.Lerp(startPos + endPos, startPos, elapsedThrust / thrustTime);
            transform.localPosition = newPos;
            yield return null;
        }

        isFiring = false;

    }

    void Update()
    {
        elapsed += !isFiring ? Time.deltaTime : 0;
        if (shouldFire && elapsed >= secondsBetweenShots && !isFiring)
        {
            elapsed = 0;
            StartCoroutine(Attack());
        }
    }

    public override void Fire()
    {
        if (!isFiring)
        {
            StartCoroutine(Attack());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (Owner == "Player" && enemy != null)
        {
            enemy.Damage((int)stats.GetStat("Player-Damage"));
        }
        else if (Owner == "Enemy" && player != null)
        {
            player.Damage((int)stats.GetStat("Enemy-Damage"));
        }
    }

    public override void Fire(bool shouldFire)
    {
        this.shouldFire = shouldFire;
    }
}
