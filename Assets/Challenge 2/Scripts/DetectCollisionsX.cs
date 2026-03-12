using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject); // destrói apenas a bola
        }
    }
}