using UnityEngine;

public class Orbit2D : MonoBehaviour
{
    public bool isEnabled = true;
    public bool shouldResetAfterEnable = false;
    public bool shouldMatchRotation = false;
    public bool shouldUseRefObject = false; // if this is true but ref is null, then fall back to orbitPosition
    public float initialAngle = 0.0f; // degrees
    public float initialSpeed = 0.0f; // degrees per second
    public float acceleration = 0.0f;
    public float primaryRadius = 1.0f;
    public float secondaryRadius = 1.0f;
    public Vector2 orbitPosition = Vector2.zero;
    public GameObject refObject = null;
    private float curAngle = 0.0f; // degrees
    private float curSpeed = 0.0f; // degrees per second

    void Start()
    {
        curAngle = initialAngle;
        curSpeed = initialSpeed;
    }

    void Update()
    {
        if (isEnabled)
        {
            if (shouldMatchRotation)
            {
                gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, curAngle);
            }

            if (shouldUseRefObject && refObject != null)
            {
                gameObject.transform.position = new Vector3(refObject.transform.position.x + (Mathf.Cos(curAngle * Mathf.Deg2Rad) * primaryRadius), refObject.transform.position.y + (Mathf.Sin(curAngle * Mathf.Deg2Rad) * secondaryRadius), 0.0f);
            }
            else
            {
                gameObject.transform.position = new Vector3(orbitPosition.x + (Mathf.Cos(curAngle * Mathf.Deg2Rad) * primaryRadius), orbitPosition.y + (Mathf.Sin(curAngle * Mathf.Deg2Rad) * secondaryRadius), 0.0f);
            }

            curAngle -= (curSpeed * Time.deltaTime);
            curSpeed += (acceleration * Time.deltaTime);
        }
        else
        {
            if (shouldResetAfterEnable)
            {
                curAngle = initialAngle;
                curSpeed = initialSpeed;
            }
        }
    }
}
