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

    // 🔥 limites
    public float maxHeight = 15f;
    public float minHeight = 0f;

    // 🔥 bounce
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
        // 🔥 subir
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < maxHeight)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // 🔥 trava no topo
        if (transform.position.y > maxHeight)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);
        }

        // 🔥 limite inferior + bounce
        if (transform.position.y < minHeight)
        {
            // trava no chão
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);

            // zera velocidade antes do bounce (IMPORTANTE)
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);

            // aplica força pra cima
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            // som
            if (bounceSound != null)
            {
                playerAudio.PlayOneShot(bounceSound, 1.0f);
            }
        }
    }

   private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Bomb") && !gameOver)
    {
        gameOver = true;

        Debug.Log("GAME OVER"); // 🔥 AGORA VAI APARECER

        explosionParticle.transform.position = transform.position;
        explosionParticle.Play();

        playerAudio.PlayOneShot(explodeSound, 1.0f);

        Destroy(other.gameObject);
    }
}
}