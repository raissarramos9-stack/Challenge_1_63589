using UnityEngine;

public class PlayerCollision7 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}