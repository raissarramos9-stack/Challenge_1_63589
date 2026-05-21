using UnityEngine;
using System.Collections;

public class PlayerController13 : MonoBehaviour
{
    private Rigidbody playerRb;

    public Transform cameraTransform;
    public float speed = 2.0f;

    // verifica se o player está com power-up
    public bool hasPowerup;

    // força do empurrão
    public float powerupStrength = 2000f;

    // indicador visual
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // indicador começa invisível
        if (powerupIndicator != null)
        {
            powerupIndicator.SetActive(false);
        }
    }

    void Update()
    {
        // indicador segue o player
        if (powerupIndicator != null)
        {
            powerupIndicator.transform.position =
                transform.position + new Vector3(0, -0.5f, 0);
        }

        // game over se cair da arena
        if (transform.position.y < -10f)
        {
            Debug.Log("GAME OVER");

            Time.timeScale = 0;
        }
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;

        // impede movimento vertical
        forward.y = 0;

        forward.Normalize();

        // movimentação do player
        playerRb.AddForce(
            forward * speed * forwardInput,
            ForceMode.Force
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        // pegou power-up
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;

            // ativa indicador
            if (powerupIndicator != null)
            {
                powerupIndicator.SetActive(true);
            }

            // remove power-up da arena
            Destroy(other.gameObject);

            // inicia contador
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // tocou no inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // se estiver com power-up
            if (hasPowerup)
            {
                Rigidbody enemyRb =
                    collision.gameObject.GetComponent<Rigidbody>();

                if (enemyRb != null)
                {
                    // direção para longe do player
                    Vector3 awayFromPlayer =
                        collision.transform.position - transform.position;

                    awayFromPlayer.y = 0;

                    // limpa velocidade antiga
                    enemyRb.linearVelocity = Vector3.zero;

                    // lança inimigo pra longe
                    enemyRb.AddForce(
                        awayFromPlayer.normalized * powerupStrength,
                        ForceMode.Impulse
                    );

                    Debug.Log("INIMIGO EMPURRADO");
                }
            }
            else
            {
                // sem power-up = game over
                Debug.Log("GAME OVER");

                Time.timeScale = 0;
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        // duração do power-up
        yield return new WaitForSeconds(5);

        hasPowerup = false;

        // desliga indicador
        if (powerupIndicator != null)
        {
            powerupIndicator.SetActive(false);
        }
    }
}