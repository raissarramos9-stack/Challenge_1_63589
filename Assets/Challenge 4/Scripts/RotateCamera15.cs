using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera15 : MonoBehaviour
{
    private float speed = 200f;
    public GameObject player;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Rotaciona ao redor do eixo Y
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        // Segurança: só move se player existir
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}