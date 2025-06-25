using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RerollButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text rerollCount;

    [SerializeField]
    Button button;

    static Player player;

    void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        int rerolls = (int)player.InGameStats.GetStat("Rerolls");
        rerollCount.text = "" + rerolls;
        button.interactable = rerolls > 0;
    }
}
