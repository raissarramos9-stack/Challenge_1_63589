using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft8 : MonoBehaviour
{
    public float speed;
    private PlayerController8 playerControllerScript;
    private float leftBound = -10;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController8>();
    }

    void Update()
    {
        // 🔒 proteção total contra null/destroy
        if (playerControllerScript == null) return;
        if (!gameObject) return;

        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // destruir com segurança TOTAL
        if (transform.position.x < leftBound && !CompareTag("Background"))
        {
            Destroy(gameObject);
            enabled = false; // 🔥 mata o Update na hora
        }
    }
}