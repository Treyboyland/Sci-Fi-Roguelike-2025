using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public bool isEnabled = true;
    public bool shouldDestroyOnStop = false;
    public bool shouldSetAngle = false;
    public float destroyTime = 0.0f; // zero means don't destroy, greater than zero means destroy after that many seconds
    public float initialSpeed = 0.0f;
    public float angleOfMotion = 0.0f; // degrees
    public float acceleration = 0.0f;
    private float curSpeed = 0.0f;

    void Start()
    {
        curSpeed = Mathf.Max(initialSpeed, 0.0f);
        if (destroyTime > 0.0f)
            Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        if (isEnabled)
        {
            if (shouldSetAngle)
            {
                gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, angleOfMotion);
            }

            gameObject.transform.Translate(new Vector3(Mathf.Cos(angleOfMotion * Mathf.Deg2Rad) * (curSpeed * Time.deltaTime), Mathf.Sin(angleOfMotion * Mathf.Deg2Rad) * (curSpeed * Time.deltaTime), 0.0f), Space.World);
            curSpeed += (acceleration * Time.deltaTime);
            curSpeed = Mathf.Max(curSpeed, 0.0f);

            if (shouldDestroyOnStop && curSpeed == 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
