using UnityEngine;

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
