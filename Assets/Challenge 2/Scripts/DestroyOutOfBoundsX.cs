using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float limiteEsquerda = -30.0f;
    private float limiteAbaixo = -6.0f;

    void Update()
    {
        if (transform.position.x < limiteEsquerda)
        {
            Destroy(gameObject);
        }

        // só destrói bolas quando caem
        if (transform.position.y < limiteAbaixo && gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }
}