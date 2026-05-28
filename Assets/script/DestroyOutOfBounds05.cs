using UnityEngine;

public class DestroyOutOfBounds5 : MonoBehaviour
{
    private float topBound = 30f;

    private void Update()
    {
        // Se sair da tela
        if (transform.position.z > topBound)
        {
            // DESATIVA AO INVÉS DE DESTROY
            gameObject.SetActive(false);
        }
    }
}