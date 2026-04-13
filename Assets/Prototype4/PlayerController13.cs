using UnityEngine;

public class PlayerController13 : MonoBehaviour
{
    private Rigidbody playerRb;
    public Transform cameraTransform; // referência da câmera
    public float speed = 5.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(cameraTransform.forward * speed * forwardInput);
    }
}