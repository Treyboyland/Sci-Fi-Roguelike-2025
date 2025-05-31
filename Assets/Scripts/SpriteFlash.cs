using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlash : MonoBehaviour
{
    public bool shouldTestFlashing = false;
    public float totalTime = 2.0f;
    public float onTime = 1.0f; // seconds
    public float offTime = 1.0f; // seconds
    public float targetOpacity = 0.0f; // >=0 and <1
    private float curTime = 0.0f;
    private float curTotalTime = 0.0f;
    private bool isFlashing = false;
    private bool isOn = false;
    private SpriteRenderer spriteRenderer = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (shouldTestFlashing)
        {
            shouldTestFlashing = false;
            StartFlash();
        }

        if (isFlashing)
        {
            curTotalTime -= Time.deltaTime;
            curTime -= Time.deltaTime;

            if (curTime <= 0.0f)
            {
                Color c = spriteRenderer.color;
                if (isOn)
                {
                    curTime = offTime;
                    c.a = targetOpacity;
                    isOn = false;
                }
                else
                {
                    curTime = onTime;
                    c.a = 1.0f;
                    isOn = true;
                }

                spriteRenderer.color = c;
            }

            if (curTotalTime < 0.0f)
            {
                StopFlash();
            }
        }
    }

    public void StartFlash()
    {
        isFlashing = true;
        InitializeFlash();
    }
    public void StopFlash()
    {
        isFlashing = false;
        Color c = spriteRenderer.color;
        c.a = 1.0f;
        spriteRenderer.color = c;
    }
    private void InitializeFlash()
    {
        Color c = spriteRenderer.color;
        c.a = targetOpacity;
        spriteRenderer.color = c;

        isOn = false;
        curTime = offTime;
        curTotalTime = totalTime;
    }
}
