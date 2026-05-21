using UnityEngine;
using TMPro;

public class ScoreManager30 : MonoBehaviour
{
    public static ScoreManager30 instance;

    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        // garante apenas uma instância
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        // verifica se o texto foi conectado
        if (scoreText == null)
        {
            Debug.LogWarning("ScoreText não está atribuído no Inspector!");
            return;
        }

        // texto inicial
        scoreText.text = "Pontos: 0";
    }

    public void AddScore(int amount = 1)
    {
        score += amount;

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontos: " + score;
        }
    }
}