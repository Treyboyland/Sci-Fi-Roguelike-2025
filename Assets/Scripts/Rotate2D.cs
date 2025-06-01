using UnityEngine;
using DG.Tweening;

public class Rotate2D : MonoBehaviour
{
    public bool isEnabled = true;
    public bool shouldResetSpeedOnEnable = true;
    public Space spaceToRotateIn = Space.Self;
    public float acceleration = 0.0f;
    public float initialRotateSpeed = 0.0f; // degrees per second
    private float curRotateSpeed = 0.0f; // degrees per second

    void Start()
    {
        curRotateSpeed = initialRotateSpeed;
        gameObject.transform.DOMove(new Vector3(8, 4, 0), 3).SetEase(Ease.OutBounce);

    }

    void Update()
    {
        if (isEnabled)
        {
            gameObject.transform.Rotate(0.0f, 0.0f, -curRotateSpeed * Time.deltaTime, spaceToRotateIn);
            curRotateSpeed += (acceleration * Time.deltaTime);
        }
        else
        {
            if (shouldResetSpeedOnEnable)
            {
                curRotateSpeed = initialRotateSpeed;
            }
        }
    }
}
