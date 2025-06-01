using UnityEngine;
using System.Collections.Generic;

public class ObjectTimers : MonoBehaviour
{
    [SerializeField]
    private List<GameTimer> timers = new List<GameTimer>(8);

    void Update()
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].state == 1)
            {
                if (timers[i].shouldUseTimeScale)
                {
                    timers[i].curTime -= Time.deltaTime;
                }
                else
                {
                    timers[i].curTime -= Time.unscaledDeltaTime;
                }

                if (timers[i].duration != 0.0f)
                {
                    timers[i].curPercent = Mathf.Max(1 - (timers[i].curTime / timers[i].duration), 0.0f);
                }

                if (timers[i].curTime <= 0.0f) // Timer completed
                {
                    timers[i].isComplete = true;
                    if (timers[i].type == GameTimer.TimerType.OneOff)
                    {
                        timers[i].curTime = 0.0f;
                        timers[i].curPercent = 1.0f;
                        timers[i].state = 0;
                    }
                    else
                    {
                        timers[i].curPercent = 0.0f;
                        timers[i].curTime = timers[i].duration;
                    }
                }
            }
        }
    }
    
    public void StartTimer(float dur, string theTag, GameTimer.TimerType theType, bool useTimeScale)
    {
        if (dur > 0.0f)
        {
            bool foundDuplicateTag = false;
            bool foundReusableSlot = false;
            int targetIndex = -1;

            // Check if there's a duplicate tag - if so then overwrite it
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i].tag == theTag)
                {
                    foundDuplicateTag = true;
                    targetIndex = i;
                    break;
                }
            }

            if (!foundDuplicateTag)
            {
                // Check if there's a reusable slot
                for (int i = 0; i < timers.Count; i++)
                {
                    if (timers[i].state == 0 && timers[i].isComplete == false)
                    {
                        foundReusableSlot = true;
                        targetIndex = i;
                        break;
                    }
                }
            }

            // Simply overwrite the index if it's duplicate or reusable - otherwise add a brand new one
            if (foundDuplicateTag || foundReusableSlot)
            {
                timers[targetIndex].state = 1;
                timers[targetIndex].duration = dur;
                timers[targetIndex].curTime = dur;
                timers[targetIndex].curPercent = 0.0f;
                timers[targetIndex].tag = theTag;
                timers[targetIndex].type = theType;
                timers[targetIndex].shouldUseTimeScale = useTimeScale;
            }
            else
            {
                GameTimer t = new GameTimer();
                t.state = 1;
                t.duration = dur;
                t.curTime = dur;
                t.curPercent = 0.0f;
                t.tag = theTag;
                t.type = theType;
                t.shouldUseTimeScale = useTimeScale;

                timers.Add(t);
            }
        }
    }
    public void PauseTimer(string tag)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag)
            {
                timers[i].state = 2;
                break;
            }
        }
    }

    public void ResumeTimer(string tag)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag && timers[i].state == 2)
            {
                timers[i].state = 1;
                break;
            }
        }
    }

    public void StopTimer(string tag)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag)
            {
                timers[i].state = 0;
                timers[i].duration = 0.0f;
                timers[i].curTime = 0.0f;
                timers[i].isComplete = false;
                break;
            }
        }
    }

    public float GetTimeRemaining(string tag)
    {
        float result = 0.0f;

        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag)
            {
                result = timers[i].curTime;
                break;
            }
        }

        return result;
    }

    public float GetPercentRemaining(string tag)
    {
        float result = 0.0f;

        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag)
            {
                result = timers[i].curPercent;
                break;
            }
        }

        return result;
    }

    public bool IsTimerComplete(string tag)
    {
        bool result = false;

        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag && timers[i].isComplete)
            {
                result = true;
                break;
            }
        }

        return result;
    }

    public void ResetCompletedTimer(string tag)
    {
        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i].tag == tag && timers[i].isComplete)
            {
                timers[i].isComplete = false;
                break;
            }
        }
    }
}
