using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public Text NameText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    private bool m_GameOver = false;

    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = { 1, 1, 2, 2, 5, 5 };

        for (int i = 0; i < LineCount; i++)
        {
            for (int x = 0; x < perLine; x++)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);

                Brick brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        if (GameOverText != null)
            GameOverText.SetActive(false);

        if (ScoreText != null)
            ScoreText.text = "Score : 0";

        if (NameText != null)
            NameText.text = "Name : " + DataManager100.Instance.PlayerName;

        if (BestScoreText != null)
            BestScoreText.text = "Best Score : " + DataManager100.Instance.BestScore;
    }

    void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;

                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1f, 0f).normalized;

                if (Ball != null)
                {
                    Ball.transform.SetParent(null);
                    Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                }
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;

        if (ScoreText != null)
            ScoreText.text = "Score : " + m_Points;
    }

    public void GameOver()
    {
        m_GameOver = true;

        if (m_Points > DataManager100.Instance.BestScore)
        {
            DataManager100.Instance.BestScore = m_Points;
            DataManager100.Instance.BestPlayerName = DataManager100.Instance.PlayerName;

            DataManager100.Instance.SaveData();

            if (BestScoreText != null)
                BestScoreText.text = "Best Score : " + DataManager100.Instance.BestScore;
        }

        if (GameOverText != null)
            GameOverText.SetActive(true);
    }
}