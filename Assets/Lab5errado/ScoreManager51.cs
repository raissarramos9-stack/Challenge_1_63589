using UnityEngine;
using TMPro;

public class ScoreManager51 : MonoBehaviour
{
    public static ScoreManager51 instance;

    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        // Garante apenas uma instância (singleton seguro)
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
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
        else
        {
            Debug.LogWarning("ScoreText não está atribuído no Inspector!");
        }
    }
}