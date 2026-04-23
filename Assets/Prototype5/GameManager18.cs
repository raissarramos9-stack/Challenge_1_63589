using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 🔥 necessário

public class GameManager18 : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton; // 🔥 NOVO

    private int score;

    [SerializeField] private float spawnRate = 1f;
    private bool isGameActive = true;

    void Start()
    {
        Time.timeScale = 1f;

        score = 0;

        if (scoreText != null)
        {
            UpdateScore(0);
        }
        else
        {
            Debug.LogError("Score Text não foi atribuído no Inspector!");
        }

        // 🔥 começa escondido
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }

        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            if (targets.Count == 0)
            {
                Debug.LogWarning("Lista de targets vazia!");
                continue;
            }

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index], RandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector2 RandomSpawnPosition()
    {
        float xRange = 4f;
        float ySpawnPos = -2f;

        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (scoreText != null)
        {
            scoreText.text = "Placar: " + score;
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        isGameActive = false;
        Time.timeScale = 0f;

        // 🔥 mostra UI
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }

    // 🔥 FUNÇÃO DO BOTÃO
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}