using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs = null;
    [SerializeField] private GameObject[] enemyPrefabs = null;
    [SerializeField] private int numEnemies = 0;
    [SerializeField] [Range(0, 1)] private float obstacleDensity = 0;

    void Start()
    {
        if (transform.childCount < numEnemies)
        {
            Debug.LogError($"Insufficient Level Objects to spawn {numEnemies} enemies");
        }

        var levelObjects = new List<LevelObject>(transform.GetComponentsInChildren<LevelObject>());
        for (int i = 0; i < numEnemies; i++)
        {
            // replace random levelObject with enemy
            int idx = Random.Range(0, levelObjects.Count);
            var enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            levelObjects[idx].Spawn(enemyToSpawn, shouldRotate: false);
            levelObjects.RemoveAt(idx);
        }


        // replace remaining levelobjects with obstacles
        foreach (var leveObject in levelObjects)
        {
            if (Random.value <= obstacleDensity)
            {
                var obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                leveObject.Spawn(obstacleToSpawn, shouldRotate: true);
            }
        }

    }

}
