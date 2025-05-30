[System.Serializable]
public class GameTimer
{
    public enum TimerType { OneOff, Regular }

    public bool shouldUseTimeScale = true;
    public bool isComplete = false;
    public int state = 0; // 0 = stopped, 1 = active, 2 = paused
    public float duration = 0.0f; // seconds
    public float curTime = 0.0f; // seconds
    public float curPercent = 0.0f; // 0-1
    public string tag = "";
    public TimerType type = TimerType.OneOff;
}
