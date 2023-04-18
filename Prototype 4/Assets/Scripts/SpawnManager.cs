using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNo = 1;

    void Start()
    {
        SpawnEnemies(waveNo);
    }

    void SpawnEnemies(int noOfEnemies)
    {
        for(int i = 1; i <=noOfEnemies; i++)
        {
        Instantiate(enemyPrefab, GenerateRandomPosition_1(), enemyPrefab.transform.rotation);
        }
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;
        if(enemyCount == 0)
        {
            waveNo++;
            SpawnEnemies(waveNo);
            Instantiate(powerUpPrefab, GenerateRandomPosition_2(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition_1()
    {
        float spawnLimit_x = Random.Range(-spawnRange, spawnRange);
        float spawnLimit_y = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnLimit_x, 0, spawnLimit_y);
        return randomPosition;
    }
    private Vector3 GenerateRandomPosition_2()
    {
        float spawnLimit_x = Random.Range(-spawnRange, spawnRange);
        float spawnLimit_y = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnLimit_x, 0, spawnLimit_y);
        return randomPosition;
    }
}
