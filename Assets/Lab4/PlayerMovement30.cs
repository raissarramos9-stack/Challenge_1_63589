using UnityEngine;

public class PlayerMovement30 : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            verticalInput,      // cima e baixo
            0f,
            -horizontalInput    // direita e esquerda
        );

        movement = movement.normalized;

        rb.MovePosition(
            rb.position + movement * speed * Time.fixedDeltaTime
        );
    }
}