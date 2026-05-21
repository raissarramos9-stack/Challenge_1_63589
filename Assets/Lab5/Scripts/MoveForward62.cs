using UnityEngine;

public class MoveForward62 : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}