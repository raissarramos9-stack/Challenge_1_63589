using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;

    void Update()
    {
        // destrói comida que sai pelo topo
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        // animal chegou ao jogador
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");

            Time.timeScale = 0; // para o jogo
        }
    }
}