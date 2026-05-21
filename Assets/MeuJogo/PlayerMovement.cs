using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        // Evita andar mais rápido na diagonal
        move = Vector3.ClampMagnitude(move, 1f);

        // Movimento suave e consistente
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}