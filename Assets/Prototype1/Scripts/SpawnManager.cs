using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject powerPrefab;
    public GameObject damagePrefab;
    private float spawnRange = 9.0f;
    private float spawnRange2 = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        //spwan enemy count = wavenumber(1)
        Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
        Instantiate(damagePrefab, SecondSpawnPosition(), damagePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            //spawn enemy count = wavenumber ++ 1
            Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
        }

        if (GameManager.score == 5)
        {
            waveNumber++;
            //SpawnEnemyWave2(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }

    /*void SpawnEnemyWave2(int enemiesToSpawn2)
    {
        for (int i = 0; i < enemiesToSpawn2; i++)
        {
            Instantiate(enemyPrefab2, SecondSpawnPosition(), enemyPrefab2.transform.rotation);

        }
    }*/

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;

    }

    private Vector3 SecondSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange2, spawnRange2);
        float spawnPosZ = Random.Range(-spawnRange2, spawnRange2);

        Vector2 randomPos2 = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos2;

    }
}
