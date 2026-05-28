using UnityEngine;
using System.Collections;

public class PlayerController03 : MonoBehaviour
{
    [Header("Configuração de movimento")]
    [SerializeField] private float velocidadeMaxima = 20f;
    [SerializeField] private float aceleracao = 10f;
    [SerializeField] private float desaceleracao = 15f;
    [SerializeField] private float velocidadeViragem = 100f;

    [Header("Nitro Boost")]
    [SerializeField] private float boostMultiplicador = 2f;
    [SerializeField] private float duracaoBoost = 2f;

    private bool emBoost = false;

    [Header("Salto simples")]
    [SerializeField] private float alturaSalto = 2f;

    [SerializeField] private float velocidadeSubida = 3f;

    private bool emSalto = false;
    private float alturaOriginal;

    private float velocidadeAtual = 0f;

    private Rigidbody rb;

    // ---------- CÂMERA ----------
    [Header("Câmera")]

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private Vector3 cameraOffset =
        new Vector3(0, 5, -10);

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        alturaOriginal = transform.position.y;

        // CONFIGURAÇÕES MELHORES DA FÍSICA
        rb.useGravity = true;

        rb.isKinematic = false;

        rb.interpolation =
            RigidbodyInterpolation.Interpolate;

        rb.collisionDetectionMode =
            CollisionDetectionMode.ContinuousDynamic;

        // NÃO DEIXA O CARRO TOMBAR
        rb.constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;

        // Procura câmera automaticamente
        if (cameraTransform == null)
        {
            cameraTransform =
                Camera.main.transform;
        }
    }

    // ---------- MOVIMENTO/FÍSICA ----------
    void FixedUpdate()
    {
        // INPUTS
        float inputVertical =
            Input.GetAxis("Vertical");

        float inputHorizontal =
            Input.GetAxis("Horizontal");

        // ACELERAÇÃO
        if (inputVertical > 0)
        {
            velocidadeAtual +=
                inputVertical *
                aceleracao *
                Time.fixedDeltaTime;
        }
        // RÉ
        else if (inputVertical < 0)
        {
            velocidadeAtual +=
                inputVertical *
                desaceleracao *
                Time.fixedDeltaTime;
        }
        // DESACELERA
        else
        {
            velocidadeAtual =
                Mathf.MoveTowards(
                    velocidadeAtual,
                    0,
                    desaceleracao *
                    Time.fixedDeltaTime
                );
        }

        // LIMITA VELOCIDADE
        velocidadeAtual =
            Mathf.Clamp(
                velocidadeAtual,
                -velocidadeMaxima,
                velocidadeMaxima
            );

        // MOVIMENTO COM FÍSICA
        rb.linearVelocity =
            transform.forward * velocidadeAtual;

        // ROTAÇÃO
        if (Mathf.Abs(velocidadeAtual) > 0.1f)
        {
            float direcao =
                velocidadeAtual > 0 ? 1f : -1f;

            Quaternion rotacao =
                Quaternion.Euler(
                    0,
                    inputHorizontal *
                    velocidadeViragem *
                    Time.fixedDeltaTime *
                    direcao,
                    0
                );

            rb.MoveRotation(
                rb.rotation * rotacao
            );
        }
    }

    // ---------- CÂMERA SUAVE ----------
    void LateUpdate()
    {
        if (cameraTransform != null)
        {
            cameraTransform.position =
                transform.position +
                transform.rotation *
                cameraOffset;

            cameraTransform.LookAt(
                transform.position +
                Vector3.up * 2
            );
        }
    }

    // ---------- INPUTS ----------
    void Update()
    {
        // NITRO
        if (Input.GetKeyDown(KeyCode.N) &&
            !emBoost)
        {
            StartCoroutine(
                AtivarBoost()
            );
        }

        // AUMENTAR TAMANHO
        if (Input.GetKey(KeyCode.Equals) ||
            Input.GetKey(KeyCode.KeypadPlus))
        {
            transform.localScale +=
                new Vector3(
                    0.5f,
                    0.5f,
                    0.5f
                ) * Time.deltaTime;
        }

        // DIMINUIR TAMANHO
        if (Input.GetKey(KeyCode.Minus) ||
            Input.GetKey(KeyCode.KeypadMinus))
        {
            transform.localScale -=
                new Vector3(
                    0.5f,
                    0.5f,
                    0.5f
                ) * Time.deltaTime;
        }

        // TROCAR COR
        if (Input.GetKeyDown(KeyCode.C))
        {
            Renderer rend =
                GetComponent<Renderer>();

            if (rend != null)
            {
                rend.material.color =
                    new Color(
                        Random.value,
                        Random.value,
                        Random.value
                    );
            }
        }

        // SALTO
        if (Input.GetKeyDown(KeyCode.Space) &&
            !emSalto)
        {
            StartCoroutine(
                Saltar()
            );
        }
    }

    // ---------- BOOST ----------
    IEnumerator AtivarBoost()
    {
        emBoost = true;

        float velocidadeOriginal =
            velocidadeMaxima;

        velocidadeMaxima *=
            boostMultiplicador;

        yield return new WaitForSeconds(
            duracaoBoost
        );

        velocidadeMaxima =
            velocidadeOriginal;

        emBoost = false;
    }

    // ---------- SALTO ----------
    IEnumerator Saltar()
    {
        emSalto = true;

        float destino =
            alturaOriginal + alturaSalto;

        // SUBIR
        while (transform.position.y < destino)
        {
            transform.position +=
                new Vector3(
                    0,
                    velocidadeSubida *
                    Time.deltaTime,
                    0
                );

            yield return null;
        }

        // DESCER
        while (transform.position.y >
               alturaOriginal)
        {
            transform.position -=
                new Vector3(
                    0,
                    velocidadeSubida *
                    Time.deltaTime,
                    0
                );

            yield return null;
        }

        // CORRIGE ALTURA
        Vector3 pos =
            transform.position;

        pos.y = alturaOriginal;

        transform.position = pos;

        emSalto = false;
    }
}