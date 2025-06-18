

public class HealthPickup :Pickup
{
[SerializeField]
int healthToHeal;

public override void PerformPickupAction(Player p)
{
player.Heal(healthToHeal);
}
}
