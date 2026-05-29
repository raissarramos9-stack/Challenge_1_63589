using System.Collections;
using UnityEngine;

public class BallSpawner09 : MonoBehaviour
{
    public GameObject BallPrefab;

    public float SpawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    private IEnumerator SpawnBalls()
    {
        while (true)
        {
            Instantiate(
                BallPrefab,
                transform.position,
                Quaternion.identity
            );

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}