using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Aim(float angle);
    public abstract void Fire();
}
