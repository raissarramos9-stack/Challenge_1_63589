using UnityEngine;

public class SpawnManager30 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float xSpawnRange = 16.0f;
    [SerializeField] private float zSpawnRange = 10.0f;
    [SerializeField] private float ySpawn = 1f; // corrigido

    [SerializeField] private float enemySpawnTime = 0.5f;

    void Start()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogWarning("Nenhum inimigo configurado no SpawnManager!");
            return;
        }

        InvokeRepeating(nameof(SpawnRandomEnemy), 1f, enemySpawnTime);
    }

    void SpawnRandomEnemy()
    {
        if (enemies == null || enemies.Length == 0) return;

        int enemyIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(
            Random.Range(-xSpawnRange, xSpawnRange),
            ySpawn,
            Random.Range(-zSpawnRange, zSpawnRange)
        );

        Instantiate(enemies[enemyIndex], spawnPos, Quaternion.identity);
    }

    public void SpawnEnemyNow()
    {
        SpawnRandomEnemy();
    }
}