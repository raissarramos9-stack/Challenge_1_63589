using UnityEngine;
using TMPro;

public class PlayerCollision62 : MonoBehaviour
{
    // Texto de GAME OVER
    public GameObject gameOverText;

    // Texto da pontuação
    public TextMeshProUGUI scoreText;

    // Variável da pontuação
    private int score = 0;

    // Detecta Trigger do inimigo
    private void OnTriggerEnter(Collider other)
    {
        // Colisão com inimigo
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER!");

            // Mostra GAME OVER
            gameOverText.SetActive(true);

            // Remove inimigo
            Destroy(other.gameObject);

            // Desativa player
            gameObject.SetActive(false);

            // Pausa o jogo
            Time.timeScale = 0;
        }
    }

    // Detecta colisão física com coletáveis
    private void OnCollisionEnter(Collision collision)
    {
        // Colisão com coletável
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Coletou item!");

            // Remove coletável
            Destroy(collision.gameObject);

            // Aumenta score
            score++;

            // Atualiza texto
            scoreText.text = "Score: " + score;
        }
    }
}