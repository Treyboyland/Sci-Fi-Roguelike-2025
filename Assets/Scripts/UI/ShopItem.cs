using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text flavorText;
    [SerializeField] TMP_Text cost;
    [SerializeField] Button button;
    static Player player;

    PlayerUpgrade upgradeData;

    public PlayerUpgrade UpgradeData
    {
        get => upgradeData;
        set
        {
            upgradeData = value;
            UpdateText();
        }
    }


    void Start()
    {
        player = player != null ? player : FindFirstObjectByType<Player>();
    }
    void Update()
    {
        button.interactable = player.GetFame() >= upgradeData.Cost;
    }

    private void UpdateText()
    {
        itemName.text = upgradeData.UpgradeName;
        description.text = upgradeData.Description;
        flavorText.text = upgradeData.FlavorText;
        cost.text = "" + upgradeData.Cost;
    }
}
