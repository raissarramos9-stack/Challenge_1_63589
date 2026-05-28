using UnityEngine;

public class PlayerGoal15 : MonoBehaviour
{
    // Arraste o texto GAME OVER aqui
    [SerializeField] private GameObject gameOverText;

    private void OnCollisionEnter(Collision collision)
    {
        // Enemy tocou no Goal
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER!");

            // Mostra texto
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // Pausa o jogo
            Time.timeScale = 0;
        }
    }
}