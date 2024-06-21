using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    [Header("Wave")]
    public Wave[] waves;
    private int nextWave = 0;
    public float waveCountdown;

    [Header("Spawn")]
    public Transform[] spawnPoints;
    public Transform[] P_spawnPoints;
    public Transform H_spawnPoints;

    public float timeBetweenWaves = 5f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    [Header("Potion")]
    public GameObject powerPrefab;
    public GameObject healthPrefab;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("35");
        }
        waveCountdown = timeBetweenWaves;
    }


    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            // Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
                //return; Looping first wave
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWaveCount(waves[nextWave]));
                //Start spawing waves;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves complete! Looping..");
            StopAllCoroutines();
            Instantiate(healthPrefab, H_spawnPoints.position, H_spawnPoints.rotation);
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

        }


        return true;
    }

    IEnumerator SpawnWaveCount(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Transform _psp = P_spawnPoints[Random.Range(0, P_spawnPoints.Length)];

        Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);
        Instantiate(powerPrefab, _sp.transform.position, powerPrefab.transform.rotation);
    }
}