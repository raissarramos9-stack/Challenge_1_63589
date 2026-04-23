using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager18 : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    private int score;

    [SerializeField] private float spawnRate = 1f;
    private bool isGameActive = true;

    void Start()
    {
        Time.timeScale = 1f; // 🔥 garante que o jogo começa normal

        score = 0;

        if (scoreText != null)
        {
            UpdateScore(0);
        }
        else
        {
            Debug.LogError("Score Text não foi atribuído no Inspector!");
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

        isGameActive = false; // 🔥 para o spawn
        Time.timeScale = 0f;  // 🔥 PARA TUDO (movimento, física, etc)
    }
}