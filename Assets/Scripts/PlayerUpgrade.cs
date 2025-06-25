using UnityEngine;

public abstract class PlayerUpgrade : ScriptableObject
{
    [SerializeField]
    protected string upgradeName;

    [SerializeField]
    protected Sprite upgradeIcon;

    [SerializeField]
    protected string flavorText;

    [SerializeField]
    int upgradeCost;

    public string UpgradeName { get => upgradeName; }
    public string FlavorText { get => flavorText; }
    public abstract string Description { get; }

    public int Cost { get => upgradeCost; }

    public abstract void ApplyUpgrade(Player p);
    public abstract void RemoveUpgrade(Player p);

}
