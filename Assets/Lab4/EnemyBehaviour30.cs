using UnityEngine;

public class EnemyBehaviour30 : MonoBehaviour
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

        if (ScoreManager30.instance != null)
        {
            ScoreManager30.instance.AddScore();
        }
        else
        {
            Debug.LogWarning("ScoreManager30.instance está null");
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