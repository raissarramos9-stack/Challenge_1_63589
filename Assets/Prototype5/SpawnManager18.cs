using UnityEngine;

public class SpawnManager18 : MonoBehaviour
{
    public GameObject[] targets;

    public float spawnRate = 1.0f;
    private float xRange = 4f;
    private float ySpawnPos = -3f;

    void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, spawnRate);
    }

    void SpawnTarget()
    {
        int index = Random.Range(0, targets.Length);

        Vector2 spawnPos = new Vector2(Random.Range(-xRange, xRange), ySpawnPos);

        Instantiate(targets[index], spawnPos, targets[index].transform.rotation);
    }
}