using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected StatBlock stats;

    public string Owner { get; set; }

    protected bool shouldFire;

    public virtual void Aim(float angle)
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public abstract void Fire();

    public abstract void Fire(bool shouldFire);
}
