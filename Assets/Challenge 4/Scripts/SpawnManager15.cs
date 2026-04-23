using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager15 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject player;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    private int waveCount = 1;
    private bool waveInProgress = false;

    void Start()
    {
        SpawnEnemyWave(waveCount);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy15>().Length;

        if (enemyCount == 0 && !waveInProgress)
        {
            waveInProgress = true;
            StartCoroutine(SpawnNextWave());
        }
    }

    IEnumerator SpawnNextWave()
    {
        yield return new WaitForSeconds(1f);

        waveCount++;
        SpawnEnemyWave(waveCount);

        waveInProgress = false;
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // power-up
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

        // inimigos com velocidade crescente 🔥
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            Enemy15 enemyScript = enemy.GetComponent<Enemy15>();

            if (enemyScript != null)
            {
                // aumenta velocidade a cada wave
                enemyScript.SetSpeed(20f + waveCount * 2f);
            }
        }

        ResetPlayerPosition();
    }

    void ResetPlayerPosition()
    {
        if (player != null)
        {
            player.transform.position = new Vector3(0, 1, -7);

            Rigidbody rb = player.GetComponent<Rigidbody>();

            // mais compatível com todas versões
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}