using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float scaleSpeed = 2f;

    Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // girar o cubo
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // mudar tamanho
        float scale = 1 + Mathf.Sin(Time.time * scaleSpeed) * 0.3f;
        transform.localScale = new Vector3(scale, scale, scale);

        // mudar cor ao longo do tempo
        float r = Mathf.Sin(Time.time) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time * 2) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time * 3) * 0.5f + 0.5f;

        cubeRenderer.material.color = new Color(r, g, b);
    }
}