using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public enum LevelState { F_level, S_level, T_level, FO_level, FI_level };

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
    public int healthCount = 0;

    [Header("Level")]
    public LevelState levelstate;

    void Start()
    {

        healthCount = 0;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("35");
        }
        waveCountdown = timeBetweenWaves;
    }


    void Update()
    {

        /* if (state == SpawnState.WAITING)
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
         }*/

        switch (levelstate)
        {
            case LevelState.F_level:
                {
                    if(GameManager.score < 5)
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

                    if (GameManager.score >= 5)
                    {
                        StopCoroutine(SpawnWaveCount(waves[nextWave]));


                        if (healthCount >= 1)
                        {
                            StopCoroutine(SpawnHealth(2));
                        }
                        else
                        {
                            if (healthCount <= 2)
                            {
                                StartCoroutine(SpawnHealth(2));
                            }
                        }

                    }
                }
                break;

            case LevelState.S_level:
                {
                    if (GameManager.score < 5) //카운트가 5 이하일때 s_level 가동 x
                    {
                        StopCoroutine(SpawnWaveCount(waves[nextWave]));

                    }
                    else //카운트가 5 이상이면 s_level 가동
                    {
                        if (GameManager.score >= 5)
                        {
                           
                            //카운트가 15 이하이면 s_level 가동 시작
                            if (GameManager.score < 10)
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

                            else //카운트가 15 이상이면 s_level 가동 종료
                            {
                                if (GameManager.score >= 10)
                                {
                                    StopCoroutine(SpawnWaveCount(waves[nextWave]));
                                }

                                if (healthCount >= 2)
                                {
                                    StopCoroutine(SpawnHealth(3));
                                }
                                else
                                {
                                    if (healthCount <= 3)
                                    {
                                        StartCoroutine(SpawnHealth(3));
                                    }
                                }

                            }
                        }
                    }
                }
                break;

            case LevelState.T_level:
                {
                    if (GameManager.score < 20)
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

                    if (GameManager.score >= 20)
                    {
                        StopCoroutine(SpawnWaveCount(waves[nextWave]));


                        if (healthCount >= 1)
                        {
                            StopCoroutine(SpawnHealth(2));
                        }
                        else
                        {
                            if (healthCount <= 2)
                            {
                                StartCoroutine(SpawnHealth(2));
                            }
                        }

                    }
                }
                break;

            case LevelState.FO_level:
                {
                    if (GameManager.score < 25)
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

                    if (GameManager.score >= 25)
                    {
                        StopCoroutine(SpawnWaveCount(waves[nextWave]));


                        if (healthCount >= 5)
                        {
                            StopCoroutine(SpawnHealth(1));
                        }
                        else
                        {
                            if (healthCount <= 6)
                            {
                                StartCoroutine(SpawnHealth(1));
                            }
                        }

                    }
                }
                break;
            case LevelState.FI_level:
                {

                }
                break;
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

    IEnumerator SpawnHealth(int _health)
    {
        
        for (int i = 0; i < _health; i++)
        {
            Instantiate(healthPrefab, H_spawnPoints.transform.position, H_spawnPoints.transform.rotation);
            healthCount += 1;

        }
        
        yield break;
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