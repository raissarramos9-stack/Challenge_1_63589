using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 30;
    public float gravityModifier = 2;

    public bool isOnGround = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}