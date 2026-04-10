using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController8 : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;

    private AudioSource playerAudio;
    public AudioClip explodeSound;

    // limites
    public float maxHeight = 15f;
    public float minHeight = 0f;

    // bounce
    public float bounceForce = 10f;
    public AudioClip bounceSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        if (gameOver) return;

        // subir
        if (Input.GetKey(KeyCode.Space) && transform.position.y < maxHeight)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // trava no topo
        if (transform.position.y > maxHeight)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);
        }

        // limite inferior + bounce
        if (transform.position.y < minHeight)
        {
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);

            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);

            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            if (bounceSound != null)
            {
                playerAudio.PlayOneShot(bounceSound, 1.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // DEBUG pra garantir que está detectando colisão
        Debug.Log("GAME OVER ");

        if (other.CompareTag("Bomb") && !gameOver)
        {
            gameOver = true;

            Debug.Log("GAME OVER"); // 🔥 vai aparecer no Console

            // Partícula
            if (explosionParticle != null)
            {
                explosionParticle.transform.position = transform.position;
                explosionParticle.Play();
            }

            // Som
            if (explodeSound != null)
            {
                playerAudio.PlayOneShot(explodeSound, 1.0f);
            }

            // Destroi a bomba
            Destroy(other.gameObject);
        }
    }
}