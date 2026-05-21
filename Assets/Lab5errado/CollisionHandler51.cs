using UnityEngine;

public class CollisionHandler51 : MonoBehaviour
{
    [SerializeField] private SpawnManager51 spawnManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HandleEnemyCollision(other.gameObject);
        }
    }

    private void HandleEnemyCollision(GameObject enemy)
    {
        Destroy(enemy);

        if (spawnManager != null)
        {
            spawnManager.SpawnEnemyNow();
        }
        else
        {
            Debug.LogWarning("SpawnManager não está atribuído!");
        }
    }
}