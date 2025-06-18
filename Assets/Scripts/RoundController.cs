using UnityEngine;

public class RoundController : Monobehaviour
{
[SerializeField]
int currentRound;

[SerializeField]
float secondsPerRound;

[SerializeField]
GameEvent<int> onRoundStarted;

[SerializeField]
GameEvent onRoundComplete;

float roundTime;

bool startRoundTime;

void Update()
{
if(startRoundTime)
{
currentRoundTime += Time.deltaTime;
if(currentRoundTime >= secondsPerRound)
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
roundTime =  0; 
currentRound++;
}
}