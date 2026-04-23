using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager18 : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject titleScreen;

    private int score;

    [SerializeField] private float spawnRate = 1f;
    private float baseSpawnRate;

    private bool isGameActive = false;

    void Start()
    {
        Time.timeScale = 1f;

        baseSpawnRate = spawnRate;

        score = 0;
        UpdateScore(0);

        // 🔥 garante estados corretos no início
        if (gameOverText != null) gameOverText.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false);

        // 🔥 ISSO FALTAVA (principal erro)
        if (titleScreen != null) titleScreen.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        if (isGameActive) return;

        isGameActive = true;

        spawnRate = baseSpawnRate / difficulty;

        score = 0;
        UpdateScore(0);

        if (titleScreen != null)
        {
            titleScreen.SetActive(false); // 🔥 esconde menu
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

        if (gameOverText != null) gameOverText.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}