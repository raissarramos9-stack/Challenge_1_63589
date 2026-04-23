using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy15 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody enemyRb;
    private Transform playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        GameObject goalObj = GameObject.FindGameObjectWithTag("PlayerGoal");

        if (goalObj != null)
        {
            playerGoal = goalObj.transform;
        }
        else
        {
            Debug.LogError("PlayerGoal NÃO encontrado! Verifique a TAG.");
        }
    }

    void FixedUpdate()
    {
        if (playerGoal == null || enemyRb == null) return;

        Vector3 direction = (playerGoal.position - transform.position).normalized;

        enemyRb.AddForce(direction * speed, ForceMode.Acceleration);
    }

    // 🔥 RECEBE VELOCIDADE DO SPAWN MANAGER
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerGoal") || other.CompareTag("EnemyGoal"))
        {
            Destroy(gameObject);
        }
    }
}