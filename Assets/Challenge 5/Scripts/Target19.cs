using System.Collections;
using UnityEngine;

public class Target19 : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager19 gameManager; // 🔥 corrigido

    public int pointValue;
    public GameObject explosionFx;

    public float timeOnScreen = 1.0f;

    private float minValueX = -3.75f;
    private float minValueY = -3.75f;
    private float spaceBetweenSquares = 2.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject gm = GameObject.Find("Game Manager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<GameManager19>(); // 🔥 corrigido
        }

        transform.position = RandomSpawnPosition();
        StartCoroutine(RemoveObjectRoutine());
    }

    private void OnMouseDown()
    {
        if (gameManager != null && gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Explode();

            if (CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        if (explosionFx != null)
        {
            Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        }
    }

    IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        if (gameManager != null && gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }
    }
}