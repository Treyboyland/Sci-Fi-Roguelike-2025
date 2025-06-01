using UnityEngine;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineBasicMultiChannelPerlin))]
public class CamShakeController : MonoBehaviour
{
    private float curTime = 0.0f; // seconds
    private float curIntensity = 0.0f;
    private float curDuration = 0.0f;
    private bool canShake = false;
    private bool shouldUseTimeScale = false;
    private bool shouldDecreaseIntensity = false;
    private CinemachineBasicMultiChannelPerlin camNoise = null;

    void Start()
    {
        camNoise = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (canShake)
        {
            if (shouldUseTimeScale)
            {
                curTime -= Time.deltaTime;
            }
            else
            {
                curTime -= Time.unscaledDeltaTime;
            }

            if (shouldDecreaseIntensity)
            {
                camNoise.AmplitudeGain = Mathf.Lerp(curIntensity, 0.0f, 1.0f - (curTime / curDuration));
            }

            if (curTime <= 0.0f)
            {
                curTime = 0.0f;
                canShake = false;
                camNoise.AmplitudeGain = 0.0f;
            }
        }
        
    }
    public void ShakeCamera(float duration, float intensity = 1.0f, bool decreaseIntensity = true, bool useTimeScale = true)
    {
        // duration is in seconds
        // reasonable values for intensity are 0.1 to 10, a good value being ~1-2
        canShake = true;
        if (duration <= 0.0f)
        {
            duration = 1.0f;
        }
        curDuration = duration;
        curTime = duration;
        curIntensity = intensity;
        camNoise.AmplitudeGain = intensity;
        shouldUseTimeScale = useTimeScale;
        shouldDecreaseIntensity = decreaseIntensity;
    }
}
