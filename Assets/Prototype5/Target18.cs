using UnityEngine;

public class Target18 : MonoBehaviour
{
    private Rigidbody2D targetRb;
    private GameManager18 gameManager;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 1.5f;

    public int pointValue = 1;
    public bool isBad = false;

    public ParticleSystem explosionParticle; // 💥 NOVO

    void Start()
    {
        targetRb = GetComponent<Rigidbody2D>();

        GameObject gm = GameObject.Find("Game Manager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<GameManager18>();
        }

        targetRb.AddForce(RandomForce(), ForceMode2D.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode2D.Impulse);
    }

    private void OnMouseDown()
    {
        // 💥 cria explosão ANTES de destruir
        if (explosionParticle != null)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

        // 🎯 pontuação
        if (gameManager != null)
        {
            gameManager.UpdateScore(pointValue);
        }

        // 💀 game over se for ruim
        if (isBad && gameManager != null)
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    Vector2 RandomForce()
    {
        return Vector2.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}