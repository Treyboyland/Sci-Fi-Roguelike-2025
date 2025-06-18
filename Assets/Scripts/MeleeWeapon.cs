public class MeleeWeapon : Monobehaviour 
{
[SerializeField]
GameStats stats;

public string Owner{get;set;}}

public void Fire(float angle)
{

}

void OnTriggerEnter2D(Collider2D other)
{
var player = other.gameObject.GetComponent<Player>();
var enemy = other.gameObject.GetComponent<Enemy>();
if(Owner == "Player" && enemy != null)
{
enemy.Damage((int)stats.GetStat("Player-Damage);
}
else if(Owner == "Enemy" && player != null)
{
player.Damage((int)stats.GetStat("Enemy-Damage);
}
}
