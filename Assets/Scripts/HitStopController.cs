using UnityEngine;

public class HitStopController : MonoBehaviour
{
    private bool canHitStop = false;
    private bool isHitStopping = false;
    private float curTime = 0.0f;
    private float prevTimeScale = 0.0f;

    void Update()
    {
        if (canHitStop)
        {
            canHitStop = false;
            prevTimeScale = Time.timeScale;
            Time.timeScale = 0.0f;
        }

        if (isHitStopping)
        {
            curTime -= Time.unscaledDeltaTime;

            if (curTime <= 0.0f)
            {
                isHitStopping = false;
                Time.timeScale = prevTimeScale;
            }
        }
    }

    public void DoHitStop(float hitStopDuration)
    {
        if (hitStopDuration > 0.0f && !isHitStopping)
        {
            canHitStop = true;
            isHitStopping = true;
            curTime = hitStopDuration;
        }
    }
}
