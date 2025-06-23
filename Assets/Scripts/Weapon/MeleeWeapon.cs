using System.Collections;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    Collider2D weaponCollider;

    IEnumerator Attack()
    {
        var startPos = transform.position;
        float thrustTime;
        float stayTime;
        float distance = 0;
        var endpos = transform.forward * distance;

        yield return null;

    }

    public override void Fire()
    {

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
        throw new System.NotImplementedException();
    }
}
