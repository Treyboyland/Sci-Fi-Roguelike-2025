using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    [SerializeField]
    protected Rigidbody2D body;

    [SerializeField]
    protected float secondsBetweenMoves;

    protected float elapsed = 0;
    protected static Player player;
    protected void Start()
    {
        FindPlayer();
    }
    protected void FindPlayer()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<Player>();
        }
    }
    protected void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= secondsBetweenMoves)
        {
            elapsed = 0;
            MoveAction();
        }
    }
    public abstract void MoveAction();
}
