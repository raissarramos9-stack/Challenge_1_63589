using UnityEngine;

public class SpawnManager13 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab; // 👈 power-up prefab

    private float spawnRange = 9f;

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        // primeira wave
        SpawnEnemyWave(waveNumber);

        // spawn inicial do power-up
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<Inimigo13>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;

            // 👇 spawn power-up ANTES da nova wave
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}