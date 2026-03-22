using UnityEngine;

public class ScrollChao : MonoBehaviour
{
    private Renderer rend;
    private float velocidade = 5f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * velocidade;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}