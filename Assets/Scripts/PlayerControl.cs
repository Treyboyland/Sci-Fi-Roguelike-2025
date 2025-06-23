using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    GameEvent<Vector2> onMove;

    //TODO: Might need to change this for keyboard vs controller[SerializeField]GameEvent<Vector2> onAim;
    [SerializeField]
    GameEvent<MovementVectorAndControl> onAim;

    [SerializeField]
    GameEvent<bool> onFire;

    [SerializeField]
    PlayerInput input;

    public void ProcessMove(InputAction.CallbackContext context)
    {
        onMove.Invoke(context.ReadValue<Vector2>());
    }
    public void ProcessAim(InputAction.CallbackContext context)
    {
        bool usingKeyboard = input != null ? input.currentControlScheme == "Keyboard&Mouse" : true;
        onAim.Invoke(new MovementVectorAndControl() { Vector = context.ReadValue<Vector2>(), IsController = !usingKeyboard });
    }
    public void ProcessFire(InputAction.CallbackContext context)
    {
        onFire.Invoke(context.ReadValueAsButton());
    }
}
