using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTelegraphScript : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(delay);

        var enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
