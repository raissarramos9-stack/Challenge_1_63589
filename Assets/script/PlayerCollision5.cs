using UnityEngine;

public class PlayerCollision5 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Debug.Log("GAME OVER!");

            Destroy(other.gameObject);
            gameObject.SetActive(false);

            Time.timeScale = 0f;
        }
    }
}