using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "StatBlock-Type-ObjectName", menuName = "Stats/Stat Block")]
public class StatBlock : ScriptableObject
{
    [SerializeField]
    List<StatAndValue> startingStats;

    public void ModifyStat(StatAndValue sv)
    {
        var stats = startingStats.Where(x => x.Stat.StatName == sv.Stat.StatName);

        for (int i = 0; i < startingStats.Count; i++)
        {
            var stat = startingStats[i];
            if (stat.Stat.StatName == sv.Stat.StatName)
            {
                stat.Value += sv.Value;
                startingStats[i] = stat;
                return;
            }
        }

        AddStat(sv);
    }


    public void AddStat(StatAndValue sv)
    {
        var stats = startingStats.Where(x => x.Stat.StatName == sv.Stat.StatName);

        if (stats.Count() != 0)
        {
            ModifyStat(sv);
        }
        else
        {
            startingStats.Add(sv);
        }
    }


    public float GetStat(string statName)
    {
        var stats = startingStats.Where(x => x.Stat.StatName == statName);

        if (stats.Count() == 0)
        {
            Debug.LogWarning($"Unable to find stat \"{statName}\" in block {name}");
        }
        if (stats.Count() > 1)
        {
            Debug.LogWarning($"Found {stats.Count()} stats with name \"{statName}\" in block {name}");
        }

        return stats.Count() != 0 ? stats.First().Value : -1;
    }

    public float GetStat(GameStat stat)
    {
        return GetStat(stat.StatName);
    }

    public StatBlock Duplicate()
    {
        StatBlock newStat = ScriptableObject.CreateInstance<StatBlock>();
        newStat.startingStats = new List<StatAndValue>();

        foreach (var stat in startingStats)
        {
            newStat.AddStat(new StatAndValue() { Stat = stat.Stat, Value = stat.Value });
        }


        return newStat;
    }
}
