using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisão com: " + other.name);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}