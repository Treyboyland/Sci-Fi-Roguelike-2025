using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
    }

    public abstract void PerformPickupAction(Player p);
}