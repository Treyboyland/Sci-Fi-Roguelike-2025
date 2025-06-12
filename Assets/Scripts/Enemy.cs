using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    StatBlock enemyStats;

    [SerializeField]
    GameEvent<Vector3> onEnemyDefeated;

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
            gameObject.SetActive(false);
        }
    }

}
