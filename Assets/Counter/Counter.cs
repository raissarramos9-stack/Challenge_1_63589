using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public float Speed = 8f;
    public float LimitZ = 8f;

    private int count = 0;

    private void Start()
    {
        count = 0;

        if (CounterText != null)
        {
            CounterText.text = "Count : 0";
        }
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;

        // Move apenas para esquerda e direita no eixo Z
        pos.z += input * Speed * Time.deltaTime;

        pos.z = Mathf.Clamp(pos.z, -LimitZ, LimitZ);

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 5;

        if (CounterText != null)
        {
            CounterText.text = "Count : " + count;
        }

        // Evita contar várias vezes a mesma bola
        Destroy(other.gameObject);
    }
}