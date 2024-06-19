using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerPrefab;
    public GameObject damagePrefab;
    public int countNumber = 1;

    [Header ("Enemy")]
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int waveNumber = 1;
    public int enemyCount;

    [Header ("Enemy2")]
    public GameObject enemyPrefab2;
    private float spawnRange2 = 9.0f;
    public int waveNumber2 = 1;
    public int enemyCount2;


    void Start()
    {
        StartCoroutine(SpawnEnemyWave(waveNumber - countNumber));
        
        //spwan enemy count = wavenumber(1)
        Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
        Instantiate(damagePrefab, SecondSpawnPosition(), damagePrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        enemyCount2 = FindObjectsOfType<Enemy2>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave(waveNumber - countNumber));
            //spawn enemy count = wavenumber ++ 1
            Instantiate(powerPrefab, GenerateSpawnPosition(), powerPrefab.transform.rotation);
            Instantiate(damagePrefab, GenerateSpawnPosition(), damagePrefab.transform.rotation);
        }

        if (GameManager.score == 5)
        {
           /* StartCoroutine(SpawnEnemyWave2(waveNumber2));
            Debug.Log("n");*/
        }
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        yield return new WaitForSeconds(3f);

    }

    /*IEnumerator SpawnEnemyWave2(int enemiesToSpawn2)
    {
        for (int i = 0; i < enemiesToSpawn2; i++)
        {
            Instantiate(enemyPrefab2, SecondSpawnPosition(), enemyPrefab2.transform.rotation);

        }
        yield return new WaitForSeconds(3f);
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
