using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager19 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText; // 🔥 NOVO

    public GameObject titleScreen;
    public Button restartButton;

    public List<GameObject> targetPrefabs;

    private int score;

    private float spawnRate = 1.5f;
    private float baseSpawnRate;

    public bool isGameActive;

    private float timeLeft; // 🔥 NOVO

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f;
    private float minValueY = -3.75f;

    void Start()
    {
        baseSpawnRate = spawnRate;

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void StartGame(int difficulty)
    {
        spawnRate = baseSpawnRate / difficulty;

        isGameActive = true;

        score = 0;
        UpdateScore(0);

        timeLeft = 60f; // 🔥 inicia tempo

        titleScreen.SetActive(false);

        StartCoroutine(SpawnTarget());
    }

    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;

            timerText.text = "Tempo: " + Mathf.Ceil(timeLeft);

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                GameOver();
            }
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targetPrefabs.Count);

            Instantiate(targetPrefabs[index],
                RandomSpawnPosition(),
                targetPrefabs[index].transform.rotation);
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Pontuação: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}