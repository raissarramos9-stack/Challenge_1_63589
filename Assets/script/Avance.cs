using UnityEngine;

public class Avance : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}