using UnityEngine;

public class Inimigo13 : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody enemyRb;
    private Transform player; // melhor usar Transform direto

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player não encontrado!");
        }
    }

    void FixedUpdate()
    {
        if (player == null) return; // evita erro se não achar o player

        Vector3 lookDirection = (player.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}