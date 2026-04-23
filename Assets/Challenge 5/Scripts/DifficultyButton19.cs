using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton19 : MonoBehaviour
{
    private Button button;
    private GameManager19 gameManager; // 🔥 corrigido

    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();

        GameObject gm = GameObject.Find("Game Manager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<GameManager19>(); // 🔥 corrigido
        }

        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        if (gameManager != null)
        {
            gameManager.StartGame(difficulty);
        }
    }
}