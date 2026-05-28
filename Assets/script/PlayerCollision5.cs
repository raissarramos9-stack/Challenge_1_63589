using UnityEngine;

public class PlayerCollision5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // COLISÃO COM ANIMAL
        if (other.CompareTag("Animal"))
        {
            Debug.Log("GAME OVER!");

            // DESATIVA O ANIMAL (POOLING)
            other.gameObject.SetActive(false);

            // DESATIVA O PLAYER
            gameObject.SetActive(false);

            // PAUSA O JOGO
            Time.timeScale = 0f;
        }
    }
}