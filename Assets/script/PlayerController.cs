using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Configuração de movimento")]
    public float velocidadeMaxima = 20f;
    public float aceleracao = 10f;
    public float desaceleracao = 15f;
    public float velocidadeViragem = 100f;

    [Header("Nitro Boost")]
    public float boostMultiplicador = 2f;
    public float duracaoBoost = 2f;
    private bool emBoost = false;

    [Header("Salto simples")]
    public float alturaSalto = 2f;
    public float velocidadeSubida = 3f;
    private bool emSalto = false;
    private float alturaOriginal;

    private float velocidadeAtual = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        alturaOriginal = transform.position.y;
    }

    void Update()
    {
        // 1️ Ler entradas
        float inputVertical = Input.GetAxis("Vertical");     // acelera / trava
        float inputHorizontal = Input.GetAxis("Horizontal"); // vira

        // 2️ Aceleração e desaceleração
        if (inputVertical > 0)
            velocidadeAtual += inputVertical * aceleracao * Time.deltaTime;
        else if (inputVertical < 0)
            velocidadeAtual += inputVertical * desaceleracao * Time.deltaTime;
        else
            velocidadeAtual = Mathf.MoveTowards(velocidadeAtual, 0, desaceleracao * Time.deltaTime);

        velocidadeAtual = Mathf.Clamp(velocidadeAtual, -velocidadeMaxima, velocidadeMaxima);

        // 3️ Movimento
        Vector3 movimento = transform.forward * velocidadeAtual * Time.deltaTime;
        transform.Translate(movimento, Space.World);

        // 4️ Só vira se estiver em movimento
        if (Mathf.Abs(velocidadeAtual) > 0.1f)
        {
            // 5️ Corrigir direção quando em marcha-atrás
            float direcao = velocidadeAtual > 0 ? 1f : -1f;
            transform.Rotate(0, inputHorizontal * velocidadeViragem * Time.deltaTime * direcao, 0);
        }

        // 6️⃣ Nitro Boost
        if (Input.GetKeyDown(KeyCode.N) && !emBoost)
            StartCoroutine(AtivarBoost());

        // 7️⃣ Alterar tamanho
        if (Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus))
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;

        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;

        // 8️⃣ Mudar cor
        if (Input.GetKeyDown(KeyCode.C))
        {
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = new Color(Random.value, Random.value, Random.value);
        }

        // 9️⃣ Salto simples
        if (Input.GetKeyDown(KeyCode.Space) && !emSalto)
            StartCoroutine(Saltar());
    }

    // --- Nitro Boost temporário ---
    IEnumerator AtivarBoost()
    {
        emBoost = true;
        float velocidadeAntiga = velocidadeMaxima;
        velocidadeMaxima *= boostMultiplicador;
        yield return new WaitForSeconds(duracaoBoost);
        velocidadeMaxima = velocidadeAntiga;
        emBoost = false;
    }

    // --- Salto simples (sem física complexa) ---
    IEnumerator Saltar()
    {
        emSalto = true;
        float destino = alturaOriginal + alturaSalto;

        // Subir
        while (transform.position.y < destino)
        {
            transform.position += new Vector3(0, velocidadeSubida * Time.deltaTime, 0);
            yield return null;
        }

        // Descer
        while (transform.position.y > alturaOriginal)
        {
            transform.position -= new Vector3(0, velocidadeSubida * Time.deltaTime, 0);
            yield return null;
        }

        // Corrigir altura
        Vector3 pos = transform.position;
        pos.y = alturaOriginal;
        transform.position = pos;

        emSalto = false;
    }
}
