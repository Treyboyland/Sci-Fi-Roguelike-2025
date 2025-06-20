using UnityEngine;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    int currentRound;

    [SerializeField]
    float secondsPerRound;

    [SerializeField]
    GameEvent<int> onRoundStarted;

    [SerializeField]
    GameEvent onRoundComplete;

    bool startRoundTime;

    float currentRoundTime;

    void Update()
    {
        if (startRoundTime)
        {
            currentRoundTime += Time.deltaTime;
            if (currentRoundTime >= secondsPerRound)
            {
                onRoundComplete.Invoke();
                StopRound();
            }
        }
    }

    public void StartRound()
    {
        startRoundTime = true;
    }

    public void StopRound()
    {
        startRoundTime = false;
    }

    public void IncreaseRound()
    {
        currentRoundTime = 0;
        currentRound++;
    }
}