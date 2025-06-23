using System;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    [SerializeField]
    Camera gameCamera;

    [SerializeField]
    Player player;

    [SerializeField]
    float radius;

    public void MoveReticle(MovementVectorAndControl control)
    {
        Action<Vector2> act = control.IsController ? SetPositionController : SetPosition;
        act(control.Vector);
    }

    public void SetPosition(Vector2 mousePosition)
    {
        Debug.LogWarning(mousePosition);
        Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, player.transform.position.z - gameCamera.transform.position.z);
        var worldPos = gameCamera.ScreenToWorldPoint(mousePos);

        //Debug.LogWarning("Reticle: " + worldPos);
        transform.position = worldPos;
    }

    public void SetPositionController(Vector2 rightStickPos)
    {
        if (rightStickPos == Vector2.zero)
        {
            return;
        }

        Vector3 newPos = rightStickPos.normalized * radius;
        newPos.z = 0;
        transform.position = newPos + player.transform.position;
    }
}
