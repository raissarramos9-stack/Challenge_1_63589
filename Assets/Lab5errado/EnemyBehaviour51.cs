using UnityEngine;

public class EnemyBehaviour51 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.CompareTag("Yellow"))
        {
            HandleCollectible(other);
        }
        else if (other.CompareTag("Cylinder"))
        {
            HandleGameOver();
        }
    }

    private void HandleCollectible(Collider other)
    {
        if (other == null) return;

        // salva referência antes de destruir
        GameObject obj = other.gameObject;

        if (ScoreManager51.instance != null)
        {
            ScoreManager51.instance.AddScore();
        }
        else
        {
            Debug.LogWarning("ScoreManager51.instance está null");
        }

        // evita múltiplas colisões no mesmo frame
        obj.SetActive(false);
    }

    private void HandleGameOver()
    {
        Debug.Log("GAME OVER");

        Time.timeScale = 0f;

        // desativa ao invés de destruir
        gameObject.SetActive(false);
    }
}