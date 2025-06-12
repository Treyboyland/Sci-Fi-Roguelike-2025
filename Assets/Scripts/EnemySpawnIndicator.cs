using UnityEngine;

public class EnemySpawnIndicator : MonoBehaviour
{
    [SerializeField]
    GameEvent<MonoBehaviour> onSpawnEnemy;

    public float SecondsBeforeSpawn { get; set; }

    public MonoBehaviour AssignedEnemy { get; set; }

    float elapsed = 0;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= SecondsBeforeSpawn)
        {
            onSpawnEnemy.Invoke();
        }
    }

    void OnEnable()
    {
        elapsed = 0;
    }
}
