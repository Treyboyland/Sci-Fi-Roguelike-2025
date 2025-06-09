using UnityEngine;

[CreateAssetMenu(fileName = "Stat-Type-Name", menuName = "Stats/Stat Type", order = -1)]
public class GameStat : ScriptableObject
{
    [SerializeField]
    string statName;

    public string StatName => statName;
}
