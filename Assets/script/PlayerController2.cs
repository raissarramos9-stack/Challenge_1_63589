using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float speed = 10f;

    [SerializeField] private float xRange = 10f;

    private float horizontalInput;

    [Header("Projétil")]
    [SerializeField] private Transform launchPoint;

    [Header("Object Pooler")]
    [SerializeField] private GameObject objectPoolerObject;

    private ObjectPooler01 objectPooler;

    void Start()
    {
        // Procura o componente ObjectPooler01
        if (objectPoolerObject != null)
        {
            objectPooler =
                objectPoolerObject.GetComponent<ObjectPooler01>();

            if (objectPooler == null)
            {
                Debug.LogError(
                    "O GameObject NÃO possui ObjectPooler01!"
                );
            }
        }
        else
        {
            Debug.LogError(
                "Object Pooler Object NÃO conectado!"
            );
        }
    }

    void Update()
    {
        // ---------- INPUT ----------
        horizontalInput =
            Input.GetAxis("Horizontal");

        // ---------- MOVIMENTO ----------
        transform.Translate(
            Vector3.right *
            horizontalInput *
            speed *
            Time.deltaTime
        );

        // ---------- LIMITES ----------
        if (transform.position.x < -xRange)
        {
            transform.position =
                new Vector3(
                    -xRange,
                    transform.position.y,
                    transform.position.z
                );
        }

        if (transform.position.x > xRange)
        {
            transform.position =
                new Vector3(
                    xRange,
                    transform.position.y,
                    transform.position.z
                );
        }

        // ---------- TIRO ----------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verifica pool
            if (objectPooler == null)
            {
                Debug.LogError(
                    "ObjectPooler01 NÃO conectado!"
                );

                return;
            }

            // Pega projétil da pool
            GameObject projectile =
                objectPooler.GetPooledObject();

            // Se existir projétil livre
            if (projectile != null)
            {
                // Define posição
                if (launchPoint != null)
                {
                    projectile.transform.position =
                        launchPoint.position;

                    projectile.transform.rotation =
                        launchPoint.rotation;
                }
                else
                {
                    projectile.transform.position =
                        transform.position +
                        new Vector3(0, 0, 2);

                    projectile.transform.rotation =
                        Quaternion.identity;
                }

                // Ativa projétil
                projectile.SetActive(true);
            }
            else
            {
                Debug.LogWarning(
                    "Nenhum projétil livre na pool!"
                );
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
    }
}