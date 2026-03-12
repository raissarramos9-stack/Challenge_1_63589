using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float tempo = 30f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        tempo -= Time.deltaTime;

        timerText.text = "Tempo: " + Mathf.Ceil(tempo).ToString();

        if (tempo <= 0)
        {
            timerText.text = "Tempo: 0";
            Time.timeScale = 0f;
        }
    }
}