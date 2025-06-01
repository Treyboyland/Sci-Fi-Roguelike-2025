using UnityEngine;

[RequireComponent(typeof(ObjectTimers))]
public class TimerTestScript : MonoBehaviour
{
    ObjectTimers timers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timers = gameObject.GetComponent<ObjectTimers>();
        timers.StartTimer(20.0f, "doSomething", GameTimer.TimerType.OneOff, true);
        timers.StartTimer(10.0f, "timeTillDupTag", GameTimer.TimerType.OneOff, true);
        timers.StartTimer(50.0f, "duplicateTag", GameTimer.TimerType.OneOff, true);
        timers.StartTimer(15.0f, "timeTillPause", GameTimer.TimerType.OneOff, true);
        timers.StartTimer(25.0f, "dropFire", GameTimer.TimerType.OneOff, true);
        timers.StartTimer(25.0f, "repeating", GameTimer.TimerType.Regular, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timers.IsTimerComplete("timeTillPause"))
        {
            timers.ResetCompletedTimer("timeTillPause");
            timers.PauseTimer("doSomething");
        }

        if (timers.IsTimerComplete("dropFire"))
        {
            timers.ResetCompletedTimer("dropFire");
            timers.StartTimer(50.0f, "thisShoudlReplaceTimeTillDupTag", GameTimer.TimerType.OneOff, true);
        }

        if (timers.IsTimerComplete("timeTillDupTag"))
        {
            timers.ResetCompletedTimer("timeTillDupTag");
            timers.StartTimer(50.0f, "duplicateTag", GameTimer.TimerType.OneOff, true);
        }
    }
}
