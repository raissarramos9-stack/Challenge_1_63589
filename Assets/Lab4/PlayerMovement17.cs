using UnityEngine;

public class PlayerMovement17 : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // 🔥 corrige só o A/D
        Vector3 movement = new Vector3(v, 0, -h);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}