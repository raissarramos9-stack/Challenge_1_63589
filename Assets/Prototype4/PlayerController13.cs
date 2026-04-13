using UnityEngine;
using System.Collections;

public class PlayerController13 : MonoBehaviour
{
    private Rigidbody playerRb;

    public Transform cameraTransform;
    public float speed = 5.0f;

    public bool hasPowerup;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator; // 👈 NOVO

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // mantém o indicador seguindo o player
        if (powerupIndicator != null)
        {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        playerRb.AddForce(forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            // ativa indicador
            powerupIndicator.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            if (enemyRb != null)
            {
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                awayFromPlayer.y = 0;

                enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        hasPowerup = false;

        // desativa indicador
        powerupIndicator.SetActive(false);
    }
}