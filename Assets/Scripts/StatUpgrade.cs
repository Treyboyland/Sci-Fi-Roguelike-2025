using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "StatUpgrade-", menuName = "Upgrades/Stat Upgrade")]
public class StatUpgrade : PlayerUpgrade
{
    [SerializeField]
    List<StatAndValue> upgradeStats;

    public override string Description
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < upgradeStats.Count; i++)
            {
                sb.Append($"{upgradeStats[i].Stat.StatName}: {upgradeStats[i].Value}");
                sb.Append(i != upgradeStats.Count - 1 ? "\r\n" : "");
            }

            return sb.ToString();
        }
    }

    public override void ApplyUpgrade(Player p)
    {
        foreach (var stat in upgradeStats)
        {
            p.InGameStats.AddStat(stat);
        }
    }

    public override void RemoveUpgrade(Player p)
    {
        foreach (var stat in upgradeStats)
        {
            p.InGameStats.ModifyStat(new StatAndValue() { Stat = stat.Stat, Value = -stat.Value });
        }
    }
}
