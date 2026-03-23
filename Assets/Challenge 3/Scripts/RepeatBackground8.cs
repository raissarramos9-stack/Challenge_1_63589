using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground8 : MonoBehaviour
{
    private Vector3 startPos;
    private float halfWidth;

    public float speed = 5f;
    private PlayerController8 playerControllerScript;

    void Start()
    {
        startPos = transform.position;

        // 🔥 usa METADE da largura (corrige o atraso)
        halfWidth = GetComponent<BoxCollider>().size.x * transform.localScale.x / 2;

        playerControllerScript = GameObject.Find("Player")
            .GetComponent<PlayerController8>();
    }

    void Update()
    {
        if (playerControllerScript != null && !playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // 🔥 reset no momento certo (sem delay)
        if (transform.position.x < startPos.x - halfWidth)
        {
            transform.position = startPos;
        }
    }
}