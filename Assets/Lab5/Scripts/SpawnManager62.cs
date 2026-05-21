using UnityEngine;

public class SpawnManager62 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject collectiblePrefab;

    // Referência do Player
    public GameObject player;

    // Distância lateral do spawn
    private float spawnRangeX = 3f;

    // Distância na frente do player
    private float spawnPosZ = 15f;

    // Alturas diferentes
    private float enemySpawnY = 0f;
    private float collectibleSpawnY = 1f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
        InvokeRepeating("SpawnCollectible", 2f, 3f);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(
            player.transform.position.x - spawnRangeX,
            player.transform.position.x + spawnRangeX
        );

        Vector3 spawnPos = new Vector3(randomX, enemySpawnY, spawnPosZ);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void SpawnCollectible()
    {
        float randomX = Random.Range(
            player.transform.position.x - spawnRangeX,
            player.transform.position.x + spawnRangeX
        );

        Vector3 spawnPos = new Vector3(randomX, collectibleSpawnY, spawnPosZ);

        Instantiate(collectiblePrefab, spawnPos, Quaternion.identity);
    }
}