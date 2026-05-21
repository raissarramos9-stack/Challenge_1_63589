using UnityEngine;

public class DestroyOutOfBounds62 : MonoBehaviour
{
    private float lowerBound = -10;

    void Update()
    {
        if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}