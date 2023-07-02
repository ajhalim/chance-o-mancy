using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class BurstProfile
{
    [System.Serializable]
    public class Shot
    {
        public DiceProfile diceProfile;
        public float fireArc;
        public int bulletCount;

        public void Shoot(Transform origin, Vector3 direction, GameObject bulletPrefab, float bulletForce) {
            float baseAngle;
            baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            baseAngle -= fireArc / 2;

            float step = fireArc / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float bulletAngle = baseAngle + step * i;
                var bulletDir = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));

                GameObject bulletInstance = MonoBehaviour.Instantiate(bulletPrefab, origin.position, Quaternion.identity);
                bulletInstance.transform.up = bulletDir;
                bulletInstance.GetComponent<diceScript>().Setup(bulletDir * bulletForce, 4, null);
            }
        }
    }

    public GameObject bulletPrefab;
    public float timeBetweenShots = 0.1f;
    public float bulletForce = 10f;
    public Shot[] shots;

    public float GetTotalFireTime()
    {
        return timeBetweenShots * (shots.Length - 1);
    }

    public IEnumerator Shoot(Transform origin, Vector3 direction)
    {
        for (int i = 0; i < shots.Length; i++)
        {
            if (i != 0) {
                yield return new WaitForSeconds(timeBetweenShots);
            }

            shots[i].Shoot(origin, direction, bulletPrefab, bulletForce);
        }

    }

}

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] float shootCooldown = 1f;
    [SerializeField] BurstProfile burstProfile = null;

    Transform player;
    float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time + shootCooldown + burstProfile.GetTotalFireTime();
        player = GameObject.FindGameObjectWithTag("Player").transform.transform;
        if (player == null)
        {
            Debug.LogError("Could not find the player! Probably forgot to tag it with \"player\"");
        }
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            //shoot
            StartCoroutine(burstProfile.Shoot(transform, player.position - transform.position));

            nextFireTime = Time.time + shootCooldown + burstProfile.GetTotalFireTime();
        }
    }
}
