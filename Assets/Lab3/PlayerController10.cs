using UnityEngine;

public class PlayerController10 : MonoBehaviour

{
    private float speed = 10f;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

   void Update()
{
    float moveX = Input.GetAxis("Horizontal");
    float moveZ = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveX, 0, moveZ);

    transform.Translate(movement * speed * Time.deltaTime);
}
void LateUpdate()
{
    if (transform.position.y < -10)
    {
        transform.position = new Vector3(0, 1, 0);
    }
}
}