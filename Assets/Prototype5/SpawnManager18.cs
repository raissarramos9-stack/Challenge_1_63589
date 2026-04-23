using System.Collections;
using UnityEngine;

public class SpawnManager18 : MonoBehaviour
{
    public GameObject[] targets;

    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float badSpawnChance = 0.25f;

    private float xRange = 4f;
    private float ySpawnPos = -2f;

    void Start()
    {
        if (targets == null || targets.Length == 0)
        {
            Debug.LogError("Nenhum target atribuído!");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int index;

            // decide se é ruim ou bom
            if (targets.Length > 1 && Random.value < badSpawnChance)
            {
                index = targets.Length - 1; // último = ruim
            }
            else
            {
                index = Random.Range(0, targets.Length - 1);
            }

            Vector2 spawnPos = new Vector2(
                Random.Range(-xRange, xRange),
                ySpawnPos
            );

            // 🔥 CORREÇÃO PRINCIPAL AQUI
            Instantiate(targets[index], spawnPos, targets[index].transform.rotation);
        }
    }
}