using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerPrefab;
    public GameObject healthPrefab;
    public int countNumber = 1;

    [Header ("Enemy")]
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int waveNumber = 10;
    public int enemyCount;

    [Header ("Enemy2")]
    public GameObject enemyPrefab2;
    private float spawnRange2 = 9.0f;
    public int waveNumber2 = 1;
    public int enemyCount2;


    void Start()
    {
        waveNumber = 1;
        StartCoroutine(SpawnEnemyWave(1));

        //spwan enemy count = wavenumber(1)
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
    }

   IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        enemiesToSpawn = waveNumber;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);

        }
        yield return new WaitForSeconds(5);

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;

    }


}
