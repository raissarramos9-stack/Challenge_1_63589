using UnityEngine;

public class SpawnManager13 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab; // 👈 ADICIONADO

    private float spawnRange = 9f;

    void Start()
    {
        // spawn inimigo
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        // spawn powerup 👇
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}