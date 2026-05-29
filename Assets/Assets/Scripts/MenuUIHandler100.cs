using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler100 : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_Text BestScoreText;

    private void Start()
    {
        if (DataManager100.Instance != null && BestScoreText != null)
        {
            BestScoreText.text =
                $"Best Score : {DataManager100.Instance.BestPlayerName} : {DataManager100.Instance.BestScore}";
        }
    }

    public void StartGame()
    {
        if (DataManager100.Instance != null)
        {
            DataManager100.Instance.PlayerName = NameInput.text.Trim();
        }

        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}