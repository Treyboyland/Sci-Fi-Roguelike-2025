using TMPro;
using UnityEngine;

public class HealthTextUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;
    int maxHealth = 0;

    public void SetAmount(int amount) { textBox.text = "" + amount + "/" + maxHealth; }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
    }
}
