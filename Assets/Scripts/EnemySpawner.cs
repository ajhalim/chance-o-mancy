using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject TelegraphPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] int startGroupSize;
    [SerializeField] int groupSizeIncreasePerMinute;
    [SerializeField] Bounds arenaBounds;

    float gameStartTime = 0f;

    int GetGroupSize()
    {
        return (int)(startGroupSize + (Time.time - gameStartTime) / 60 * groupSizeIncreasePerMinute);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStartTime = Time.time;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < GetGroupSize(); i++)
            {
                Vector2 spawnPoint = new Vector2(Random.Range(arenaBounds.min.x, arenaBounds.max.x), Random.Range(arenaBounds.min.y, arenaBounds.max.y));
                Instantiate(TelegraphPrefab, spawnPoint, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
