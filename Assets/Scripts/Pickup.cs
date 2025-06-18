public abstract class Pickup : Monobehvaiour
{
public void OnTriggerEnter2D(Collider2D other)
{
var player = other.gameObject.GetComponent<Player>();
}

public abstract void PerformPickupAction(Player p);
}