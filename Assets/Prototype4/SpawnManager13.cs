using UnityEngine;
using System.Collections;

public class SpawnManager13 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9f;

    void Start()
    {
        // primeiro inimigo
        SpawnEnemy();

        // primeiro power-up
        SpawnPowerup();

        // começa rotinas
        StartCoroutine(SpawnEnemiesRoutine());
        StartCoroutine(SpawnPowerupsRoutine());
    }

    // cria 1 inimigo
    void SpawnEnemy()
    {
        Instantiate(
            enemyPrefab,
            GenerateSpawnPosition(),
            enemyPrefab.transform.rotation
        );
    }

    // cria 1 power-up
    void SpawnPowerup()
    {
        Instantiate(
            powerupPrefab,
            GenerateSpawnPosition(),
            powerupPrefab.transform.rotation
        );
    }

    // inimigo a cada 6 segundos
    IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            SpawnEnemy();
        }
    }

    // power-up a cada 6 segundos
    IEnumerator SpawnPowerupsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            SpawnPowerup();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX =
            Random.Range(-spawnRange, spawnRange);

        float spawnPosZ =
            Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}