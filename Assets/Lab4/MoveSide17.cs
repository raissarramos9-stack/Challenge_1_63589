using UnityEngine;

public class MoveSide17 : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 🔥 movimento lateral
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}