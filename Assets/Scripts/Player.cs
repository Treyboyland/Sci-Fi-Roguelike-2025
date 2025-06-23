using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    StatBlock startingStats;

    [SerializeField]
    GameEvent<Vector3> onPlayerDamaged;

    [SerializeField]
    GameEvent<Vector3> onPlayerDeath;

    [SerializeField]
    GameEvent<int> onHealthUpdated;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    Weapon currentWeapon;

    StatBlock inGameStats;
    public StatBlock InGameStats { get => inGameStats; set { inGameStats = value.Duplicate(); } }
    int currentHealth;

    Vector2 movementVector;
    void Start()
    {
        inGameStats = startingStats.Duplicate();
        currentHealth = (int)inGameStats.GetStat("Player-MaxHP");
        onHealthUpdated.Invoke(currentHealth);
    }
    public void Damage(int damage)
    {
        var previousHealth = currentHealth; currentHealth = Mathf.Max(0, currentHealth - damage);
        if (currentHealth != previousHealth && currentHealth != 0)
        {
            onPlayerDamaged.Invoke(transform.position);

        }
        onHealthUpdated.Invoke(currentHealth);
        if (currentHealth == 0)
        {
            onPlayerDeath.Invoke(transform.position);
        }
    }

    public void Heal(int health)
    {
        currentHealth = Mathf.Min((int)inGameStats.GetStat("Player-MaxHP"), currentHealth + health);
        onHealthUpdated.Invoke(currentHealth);
    }

    void FixedUpdate()
    {
        if (movementVector != Vector2.zero)
        {
            body.MovePosition((Vector2)transform.position + (movementVector * (inGameStats.GetStat("Player-MaxMoveSpeed") * Time.fixedDeltaTime)));
        }
    }

    public void MovePlayer(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }
}
