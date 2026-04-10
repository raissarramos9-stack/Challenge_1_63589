using UnityEngine;

public class RepetirFundoP3 : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private float largura;

    void Start()
    {
        posicaoInicial = transform.position;
        largura = GetComponent<Renderer>().bounds.size.x * 0.4f;
    }

    void Update()
    {
        // Quando sair pela direita, volta pra posição inicial
        if (transform.position.x > posicaoInicial.x + largura)
        {
            transform.position = posicaoInicial;
        }
    }
}