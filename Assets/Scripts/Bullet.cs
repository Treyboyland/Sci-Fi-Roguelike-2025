using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float lifeTime;

    public int Damage { get; set; }

    float elapsed = 0;

    int currentHits;

    public string Owner { get; set; }

    public bool IsPiercing { get; set; }

    public int MaxHits { get; set; }

    public float LifeTime
    {
        get => lifeTime;
        set => lifeTime = value;
    }

    void OnEnable()
    {
        elapsed = 0;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (Owner == "Player" && enemy != null)
        {
            enemy.Damage(Damage);
            currentHits++;
            if (MaxHits <= 0 || currentHits > MaxHits)
            {
                gameObject.SetActive(false);
            }
        }
        else if (Owner == "Enemy" && player != null)
        {
            player.Damage(Damage);
            currentHits++;
            if (MaxHits <= 0 || currentHits > MaxHits)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
