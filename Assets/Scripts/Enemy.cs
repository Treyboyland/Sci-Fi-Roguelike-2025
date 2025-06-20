using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    StatBlock enemyStats;

    [Tooltip("For general defeat of enemy stuff (e.g. death particles or noises)")]
    [SerializeField]
    GameEvent<Vector3> onEnemyDefeated;

    [Tooltip("Specifically for something that should happen on death for this type of enemy")]
    [SerializeField]
    GameEvent<Vector3> onThisEnemyDeath;

    public StatBlock Stats { get { return enemyStats; } }

    int currentHealth;

    void Start()
    {
        currentHealth = (int)enemyStats.GetStat("Enemy-MaxHP");
    }

    public void Damage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        if (currentHealth == 0)
        {
            onEnemyDefeated.Invoke(transform.position);
            onThisEnemyDeath.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }

}
