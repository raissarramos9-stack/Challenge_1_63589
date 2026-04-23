using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager18 : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1f;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index], RandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector2 RandomSpawnPosition()
    {
        float xRange = 4f;
        float ySpawnPos = -3f;

        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }
}