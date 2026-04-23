using UnityEngine;

public class Target18 : MonoBehaviour
{
    private Rigidbody2D targetRb;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 3f;
    private float xRange = 4f;
    private float ySpawnPos = -3f;

    void Start()
    {
        targetRb = GetComponent<Rigidbody2D>();

        targetRb.AddForce(RandomForce(), ForceMode2D.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode2D.Impulse);

        transform.position = RandomSpawnPos();
    }

    // 🔥 clicar destrói
  private void OnMouseDown()
{
    if (gameObject.CompareTag("Bad"))
    {
        Debug.Log("GAME OVER");

        Time.timeScale = 0f; // 🔥 pausa o jogo
    }

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

    Vector2 RandomSpawnPos()
    {
        return new Vector2(Random.Range(-xRange, xRange), ySpawnPos);
    }
}