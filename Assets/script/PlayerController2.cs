using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;

    public GameObject projectilePrefab;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = transform.position + new Vector3(0, 0, 2);
            Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
    }
}