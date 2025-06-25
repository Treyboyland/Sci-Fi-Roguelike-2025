using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    Weapon weapon;

    static Player player;

    void Start()
    {
        button.onClick.AddListener(EquipWeapon);
    }

    void EquipWeapon()
    {
        player = FindFirstObjectByType<Player>();
        if (player)
        {
            player.CurrentWeapon = weapon;
        }
    }
}
