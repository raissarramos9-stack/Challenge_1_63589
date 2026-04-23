using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager17 : MonoBehaviour
{
    public GameObject[] enemies;

    private float zEnemySpawn = 0f;
    private float xSpawnRange = 16.0f;
    private float ySpawn = 0.75f;

    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    void Start()
    {
        if (enemies.Length == 0)
        {
            Debug.LogError("Nenhum inimigo atribuído!");
            return;
        }

        InvokeRepeating(nameof(SpawnRandomEnemy), startDelay, enemySpawnTime);
    }

    // 🔥 SPAWN CONTÍNUO
    void SpawnRandomEnemy()
    {
        if (enemies.Length == 0) return;

        int enemyIndex = Random.Range(0, enemies.Length);
        GameObject enemyPrefab = enemies[enemyIndex];

        if (enemyPrefab == null)
        {
            Debug.LogWarning("Prefab de inimigo está vazio!");
            return;
        }

        Vector3 spawnPos = new Vector3(
            Random.Range(-xSpawnRange, xSpawnRange),
            ySpawn,
            zEnemySpawn
        );

        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }

    // 🔥 SPAWN IMEDIATO (quando um inimigo morre)
    public void SpawnEnemyNow()
    {
        SpawnRandomEnemy();
    }
}