using UnityEngine;

public class ObstacleCollision01 : MonoBehaviour
{
    [Header("Força para derrubar")]
    [SerializeField] private float forcaEmpurrao = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Garante física correta
        rb.useGravity = true;
        rb.isKinematic = false;

        rb.collisionDetectionMode =
            CollisionDetectionMode.Continuous;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta carro/player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Obstacle bateu no Player!");

            // Direção do impacto
            Vector3 direcao =
                (transform.position -
                collision.transform.position).normalized;

            // Derruba o obstáculo
            rb.AddForce(
                direcao * forcaEmpurrao,
                ForceMode.Impulse
            );

            // Faz girar também
            rb.AddTorque(
                Random.insideUnitSphere * forcaEmpurrao,
                ForceMode.Impulse
            );
        }
    }
}