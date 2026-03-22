using UnityEngine;

public class RepetirFundoP3 : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private float largura;

    void Start()
    {
        posicaoInicial = transform.position;

        // AJUSTE AQUI ↓↓↓
        largura = GetComponent<Renderer>().bounds.size.x * 0.3f;
    }

    void Update()
    {
        if (transform.position.x > posicaoInicial.x + largura)
        {
            transform.position = posicaoInicial;
        }
    }
}