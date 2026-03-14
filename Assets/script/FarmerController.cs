using UnityEngine;

public class FarmerController5 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 15.0f;
    public float xRange = 20.0f;

    public GameObject projectilePrefab;

    void Update()
    {
        // Movimento horizontal
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Limites do player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);

            GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

            // Ignorar colisão com o player
            Collider playerCol = GetComponent<Collider>();
            Collider projCol = projectile.GetComponent<Collider>();

            if (playerCol != null && projCol != null)
            {
                Physics.IgnoreCollision(projCol, playerCol);
            }
        }
    }
}