using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy15 : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    // CONTADOR DE ACERTOS
    private static int acertos = 0;

    private Rigidbody enemyRb;
    private Transform playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        // Procura o PlayerGoal
        GameObject goalObj =
            GameObject.FindGameObjectWithTag("PlayerGoal");

        if (goalObj != null)
        {
            playerGoal = goalObj.transform;
        }
        else
        {
            Debug.LogError(
                "PlayerGoal NÃO encontrado! Verifique a TAG."
            );
        }
    }

    void FixedUpdate()
    {
        if (playerGoal == null || enemyRb == null)
            return;

        // Direção até o goal
        Vector3 direction =
            (playerGoal.position - transform.position).normalized;

        // Movimento do inimigo
        enemyRb.AddForce(
            direction * speed,
            ForceMode.Acceleration
        );
    }

    // RECEBE VELOCIDADE DO SPAWN MANAGER
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ---------- PLAYER GOAL ----------
        if (other.CompareTag("PlayerGoal"))
        {
            Debug.Log("GAME OVER!");

            Destroy(gameObject);
        }

        // ---------- ENEMY GOAL ----------
        if (other.CompareTag("EnemyGoal"))
        {
            // Soma acertos
            acertos++;

            // Mostra no Console
            Debug.Log(acertos + " acertos");

            // Destrói inimigo
            Destroy(gameObject);
        }
    }
}