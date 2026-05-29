using System.Collections;
using UnityEngine;

public class SpawnManager09 : MonoBehaviour
{
    public GameObject BallPrefab;

    public Transform Caixa;

    public float SpawnInterval = 2f;

    public float AlturaSpawn = 10f;

    public float Dispersao = 1.5f;

    private IEnumerator Start()
    {
        while (true)
        {
            float offset = Random.Range(-Dispersao, Dispersao);

            Vector3 spawnPosition = new Vector3(
                Caixa.position.x + offset,
                AlturaSpawn,
                Caixa.position.z
            );

            Instantiate(
                BallPrefab,
                spawnPosition,
                Quaternion.identity
            );

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}