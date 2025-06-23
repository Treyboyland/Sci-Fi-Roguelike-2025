using UnityEngine;

public class ReticleTracker : MonoBehaviour
{
    static PlayerReticle reticle;

    [SerializeField]
    SpriteRenderer sprite;

    [Tooltip("If the sprite isn't oriented to the right, add this to the angle")]
    [SerializeField]
    float spriteCorrectionAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (reticle == null)
        {
            reticle = FindAnyObjectByType<PlayerReticle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reticle != null)
        {
            var pos = reticle.transform.position - transform.position;
            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg + spriteCorrectionAngle;
            sprite.flipX = (angle + 360) % 360 > 180;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
