using UnityEngine;

public class CollisionHandler30 : MonoBehaviour
{
    private SpawnManager30 spawnManager;

    void Start()
    {
        // procura automaticamente o SpawnManager na cena
        spawnManager = FindObjectOfType<SpawnManager30>();

        if (spawnManager == null)
        {
            Debug.LogWarning("SpawnManager não encontrado na cena!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // quando tocar no amarelo
        if (other.gameObject.CompareTag("Yellow"))
        {
            HandleYellowCollision(other.gameObject);
        }

        // quando tocar no vermelho
        if (other.gameObject.CompareTag("Red"))
        {
            HandleGameOver();
        }
    }

    private void HandleYellowCollision(GameObject yellow)
    {
        // adiciona pontos
        if (ScoreManager30.instance != null)
        {
            ScoreManager30.instance.AddScore();
        }

        // desativa o amarelo
        yellow.SetActive(false);

        // cria outro objeto
        if (spawnManager != null)
        {
            spawnManager.SpawnEnemyNow();
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("GAME OVER");

        // pausa o jogo
        Time.timeScale = 0f;
    }
}