using UnityEngine;

public class GeradorObstaculosP3 : MonoBehaviour
{
    public GameObject[] prefabs;

    [SerializeField] private float distanciaSpawn = 10f;
    [SerializeField] private float intervaloEspera = 2f;

    public Transform player;

    void Start()
    {
        if (player == null)
        {
            GameObject obj = GameObject.Find("SimplePeople");

            if (obj != null)
                player = obj.transform;
            else
            {
                Debug.LogError("Player não encontrado!");
                return;
            }
        }

        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError("Lista de Prefabs vazia!");
            return;
        }

        InvokeRepeating(nameof(GerarObstaculo), 1f, intervaloEspera);
    }

void GerarObstaculo()
{
    int index = Random.Range(0, prefabs.Length);

    Vector3 posicaoSpawn = new Vector3(
        66.88f,
        -3.9868f,
        5.7468f
    );

    GameObject obj = Instantiate(prefabs[index], posicaoSpawn, Quaternion.identity);

    Debug.Log("Spawnou obstáculo em: " + posicaoSpawn);

    obj.transform.localScale = Vector3.one;
    obj.SetActive(true);
}
}