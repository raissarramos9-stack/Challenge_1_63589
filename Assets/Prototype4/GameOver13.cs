using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver13 : MonoBehaviour
{
    private PlayerController13 playerController;

    void Start()
    {
        // pega o script do player
        playerController =
            GetComponent<PlayerController13>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // verifica se bateu em inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // só dá game over se NÃO tiver power-up
            if (!playerController.hasPowerup)
            {
                Debug.Log("GAME OVER");

                // pausa o jogo
                Time.timeScale = 0;

                // opcional:
                // Invoke(nameof(RestartGame), 2f);
            }
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}