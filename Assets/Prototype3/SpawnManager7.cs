using UnityEngine;

public class SpawnManager7 : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(90f, -4f, 5.6f);

    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}