using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] // 🔥 garante que tem Button
public class DifficultyButton18 : MonoBehaviour
{
    private Button button;
    private GameManager18 gameManager;

    [SerializeField] private int difficulty = 1; // 🔥 editável no Inspector

    void Awake()
    {
        button = GetComponent<Button>();

        gameManager = FindObjectOfType<GameManager18>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado na cena!");
        }
    }

    void OnEnable()
    {
        button.onClick.AddListener(SetDifficulty);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(SetDifficulty); // 🔥 evita duplicação
    }

    void SetDifficulty()
    {
        if (gameManager != null)
        {
            gameManager.StartGame(difficulty);
        }
    }
}