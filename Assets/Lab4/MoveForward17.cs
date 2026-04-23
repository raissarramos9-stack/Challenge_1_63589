using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward17 : MonoBehaviour
{
    public float speed = 10f;
    public float yDestroy = 30f; // limite da tela

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 🔥 destruir quando sair da tela
        if (transform.position.y > yDestroy)
        {
            Destroy(gameObject);
        }
    }
}