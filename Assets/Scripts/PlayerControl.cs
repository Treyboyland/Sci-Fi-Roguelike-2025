using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
   [SerializeField]
   GameEvent<Vector2> onMove;

   //TODO: Might need to change this for keyboard vs controller[SerializeField]GameEvent<Vector2> onAim;
   [SerializeField]
   GameEvent<Vector2> onAim;

   [SerializeField]
   GameEvent<bool> onFire;

   public void ProcessMove(InputAction.CallbackContext context)
   {
      onMove.Invoke(context.ReadValue<Vector2>());
   }
   public void ProcessAim(InputAction.CallbackContext context)
   {
      onAim.Invoke(context.ReadValue<Vector2>());
   }
   public void ProcessFire(InputAction.CallbackContext context)
   {
      onFire.Invoke(context.ReadValueAsButton());
   }
}
