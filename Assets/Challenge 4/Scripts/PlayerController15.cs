using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController15 : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500f;
    private GameObject focalPoint;

    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public float powerUpDuration = 5f;

    private float normalStrength = 15f;
    private float powerupStrength = 30f;

    private Coroutine powerupCoroutine;

    // 🔥 BOOST
    public float boostStrength = 500f;

    // ✨ PARTÍCULAS
    public ParticleSystem boostParticles;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

        if (powerupIndicator != null)
        {
            powerupIndicator.SetActive(false);
        }
    }

    void Update()
    {
        // 🔥 BOOST com espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(focalPoint.transform.forward * boostStrength, ForceMode.Impulse);

            // ✨ ativa partículas
            if (boostParticles != null)
            {
                boostParticles.Play();
            }
        }

        if (powerupIndicator != null)
        {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        }
    }

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (focalPoint != null)
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);

            hasPowerup = true;

            if (powerupIndicator != null)
            {
                powerupIndicator.SetActive(true);
            }

            if (powerupCoroutine != null)
            {
                StopCoroutine(powerupCoroutine);
            }

            powerupCoroutine = StartCoroutine(PowerupCooldown());
        }
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);

        hasPowerup = false;

        if (powerupIndicator != null)
        {
            powerupIndicator.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            if (enemyRb != null)
            {
                Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized;

                float strength = hasPowerup ? powerupStrength : normalStrength;

                enemyRb.AddForce(awayFromPlayer * strength, ForceMode.Impulse);
            }
        }
    }
}