using UnityEngine;

public class PlayerMovement51 : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // direção baseada na câmera
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        // remove inclinação da câmera
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * verticalInput + right * horizontalInput;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}