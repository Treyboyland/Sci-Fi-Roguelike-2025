using TMPro;
using UnityEngine;

public class NumberText : MonoBehaviour
{
    [SerializeField] TMP_Text textBox;
    public void SetAmount(int amount)
    {
        textBox.text = "" + amount;
    }
}
