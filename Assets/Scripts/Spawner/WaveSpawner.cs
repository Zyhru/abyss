using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public enum State
    {
        Idle,
        Spawning,
        Waiting
    }

    public static WaveSpawner instance;
    public State state;


    // Every 30 seconds increase wave
    // Timer that keeps count of every 30 seconds

    public EnemyBase[] enemies;
    public GameObject[] items;
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Transform[] itemSpawnPoints;
    public ChaosMeter chaosMeter;

    [SerializeField] private int increaseDifficulty;
    [SerializeField] private int waveCount;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnChance;



    private Transform sp;
    private float enemyAliveTimer = 1f;
    private bool waveIncreased;
    private int waveIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        
        sp = itemSpawnPoints[Random.Range(0, items.Length)];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Waiting)
        {
            if (!EnemyAlive())
            {
                // Increase Wave
                IncreaseWave();
            }
            else
            {
                return;
            }
        }


        if (state == State.Idle)
        {
            StartCoroutine(CommenceWave(waves[waveIndex]));
        }
    }


    private bool EnemyAlive()
    {
        enemyAliveTimer -= Time.deltaTime;


        if (enemyAliveTimer <= 0)
        {
            enemyAliveTimer = 1f;
            
            // Check to see if enemy is dead
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
            
            
        }


        return true;
    }

    public void SpawnHearts(Vector3 pos)
    {
        int randomPowerUp = Random.Range(0, items.Length);
        if (Random.value < spawnChance)
        {
            Instantiate(items[randomPowerUp], pos, Quaternion.identity);
        }
    }
    
    void SpawnItem()
    {
        int randomPowerUp = Random.Range(0, items.Length);
        if (Random.value < spawnChance)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(items[randomPowerUp], sp.position, Quaternion.identity);
            }
        }
        
    }
    
    private void IncreaseEnemyStats()
    {
        SpawnItem();

        chaosMeter.ChaosDecreaseAmount += .005f;
        spawnRate -= 0.1f;


        if (spawnRate <= 0.2f)
        {
            spawnRate = 0.2f;
        }


        if (chaosMeter.ChaosDecreaseAmount >= 0.1f)
        {
            chaosMeter.ChaosDecreaseAmount = 0.1f;
        }


        // Increase basic enemy speed, health and damage     
        foreach (EnemyBase enemy in enemies)
        {
            enemy.Damage += increaseDifficulty;
            enemy.Health += increaseDifficulty;
            enemy.Speed += increaseDifficulty;
        }

        state = State.Idle;
    }


    void IncreaseWave()
    {
        if (waveIndex >= waves.Length - 1)
        {
            waveIndex = 0;
            // Increasing enemy count when wave count resets
            IncreaseEnemyCount();
        }
        else
        {
            waveIndex++;
            waveIncreased = true;
            IncreaseEnemyStats();

        }
    }

    private void IncreaseEnemyCount()
    {
        foreach (var wave in waves)
        {
            foreach (Enemies enemies in wave.enemies)
            {
                enemies.enemyCount++;
            }
        }
    }


    IEnumerator CommenceWave(Wave _wave)
    {
        state = State.Spawning;
        waveCount++;


            
        if (waveIncreased)
        {
            
            GameObject[] upgrades = GameObject.FindGameObjectsWithTag("Upgrade");
            foreach (GameObject upgrade in upgrades)
            {
                Destroy(upgrade);
            }
            
        }
        

        foreach (Enemies enemies in _wave.enemies)
        {
            for (int i = 0; i < enemies.enemyCount; i++)
            {
                // Spawn Enemy
                SpawnEnemy(enemies.enemy);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        state = State.Waiting;
    }

    void SpawnEnemy(GameObject e)
    {
        // Select random spawn points
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(e, sp.position, Quaternion.identity);
    }


    public int WaveCount => waveCount;

    

    [System.Serializable]
    public class Enemies
    {
        public GameObject enemy;
        public int enemyCount;
    }

    [System.Serializable]
    public class Wave
    {
        public List<Enemies> enemies;
    }
}