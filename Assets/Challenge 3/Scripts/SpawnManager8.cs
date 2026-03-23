using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager8 : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnDelay = 2f;
    public float spawnInterval = 1.5f;

    private PlayerController8 playerControllerScript;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController8>();

        if (playerControllerScript == null)
        {
            Debug.LogError("PlayerController8 não encontrado na cena!");
            return;
        }

        InvokeRepeating(nameof(SpawnObjects), spawnDelay, spawnInterval);
    }

    void SpawnObjects()
    {
        // 🔥 CORREÇÃO PRINCIPAL
        if (playerControllerScript == null)
        {
            CancelInvoke(); // 🔥 PARA o loop
            return;
        }

        if (playerControllerScript.gameOver)
        {
            CancelInvoke(); // 🔥 PARA quando acaba o jogo
            return;
        }

        if (objectPrefabs == null || objectPrefabs.Length == 0)
        {
            Debug.LogWarning("Nenhum prefab foi atribuído no SpawnManager!");
            return;
        }

        Vector3 spawnLocation = new Vector3(25f, Random.Range(5f, 12f), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
    }
}