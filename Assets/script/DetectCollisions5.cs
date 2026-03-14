using UnityEngine;

public class DetectCollisions5 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}