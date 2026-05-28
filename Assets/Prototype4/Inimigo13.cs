using UnityEngine;
using System.Collections;

public class Inimigo13 : MonoBehaviour
{
    public float speed = 16f;

    // CONTADOR DE GANHOS
    private static int ganhos = 0;

    private Rigidbody enemyRb;
    private Transform player;

    // controla se pode perseguir
    private bool canMove = true;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        GameObject playerObj =
            GameObject.Find("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null || !canMove)
            return;

        // direção até player
        Vector3 lookDirection =
            (player.position - transform.position).normalized;

        // movimento
        enemyRb.AddForce(
            lookDirection * speed,
            ForceMode.Force
        );

        // VERIFICA SE O INIMIGO CAIU
        if (transform.position.y < -5f)
        {
            // soma ganho
            ganhos++;

            // mostra no console
            Debug.Log("+1 ganho! Total: " + ganhos);

            // destrói inimigo
            Destroy(gameObject);
        }
    }

    public void Knockback(Vector3 force)
    {
        StartCoroutine(
            KnockbackRoutine(force)
        );
    }

    IEnumerator KnockbackRoutine(Vector3 force)
    {
        // inimigo para de perseguir
        canMove = false;

        // limpa velocidade antiga
        enemyRb.linearVelocity =
            Vector3.zero;

        // aplica empurrão
        enemyRb.AddForce(
            force,
            ForceMode.Impulse
        );

        // espera um pouco
        yield return new WaitForSeconds(1f);

        // volta a perseguir
        canMove = true;
    }
}