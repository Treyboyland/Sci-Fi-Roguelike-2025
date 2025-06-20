

using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField]
    int healthToHeal;

    public override void PerformPickupAction(Player p)
    {
        p.Heal(healthToHeal);
        gameObject.SetActive(false);
    }
}
