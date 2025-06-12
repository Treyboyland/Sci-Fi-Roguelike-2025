using UnityEngine;

public class EnemyMoveAwayFromPlayer : EnemyMovement
{
   public override void MoveAction()
   {
      FindPlayer();
      var movementVector = (transform.position - player.transform.position).normalized;
      movementVector *= enemy.Stats.GetStat("Enemy-MoveSpeed");
      body.AddForce(movementVector);
   }
}
