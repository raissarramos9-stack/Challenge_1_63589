using UnityEngine;

public class CollisionHandler17 : MonoBehaviour
{
    public SpawnManager17 spawnManager; // 🔥 referência ao spawn

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colidiu com: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            // 🔥 faz nascer outro imediatamente
            if (spawnManager != null)
            {
                spawnManager.SpawnEnemyNow();
            }
        }
    }
}