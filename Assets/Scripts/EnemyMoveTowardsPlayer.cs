using UnityEngine;

public class EnemyMoveTowardsPlayer : EnemyMovement
{
    public override void MoveAction()
    {
        FindPlayer();
        var movementVector = (player.transform.position - transform.position).normalized;
        movementVector *= enemy.Stats.GetStat("Enemy-MoveSpeed");
        body.AddForce(movementVector);
    }
}

