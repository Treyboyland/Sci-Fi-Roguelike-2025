using UnityEngine;

public class TestBulletSpawn : MonoBehaviour
{
    public Bullet2D bulletToSpawn =  null;
    public float spawnRate = 1.0f;
    public int numToSpawn = 1;
    public float rndX = 0.0f;
    public float rndY = 0.0f;
    private float timer = 0.0f;
    private bool canSpawn = true;

    void Update()
    {
        if (timer <= 0.0f)
        {
            timer = spawnRate;
            canSpawn = true;
        }

        if (bulletToSpawn != null && canSpawn)
        {
            canSpawn = false;
            Vector3 posToSpawn = gameObject.transform.position;
            
            for (int i = 0; i < numToSpawn; i++)
            {
                posToSpawn.x += Random.Range(-rndX, rndX);
                posToSpawn.y += Random.Range(-rndY, rndY);

                Bullet2D b = Instantiate(bulletToSpawn, posToSpawn, gameObject.transform.rotation);
                b.angleOfMotion = gameObject.transform.rotation.eulerAngles.z;
            }
        }

        timer -= Time.deltaTime;
    }
}
