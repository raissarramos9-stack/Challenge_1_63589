using UnityEngine;

public class MoverCenarioEsquerda : MonoBehaviour
{
    private float velocidade = 30f;
    private ControladorPersonagemP3 scriptControle;

    void Start()
    {
        scriptControle = GameObject.Find("SimplePeople").GetComponent<ControladorPersonagemP3>();
    }

    void Update()
    {
        if (scriptControle != null && !scriptControle.gameOver)
        {
            // AGORA PRA DIREITA (ok!)
            transform.Translate(Vector3.right * Time.deltaTime * velocidade);
        }

        if (transform.position.x > 200 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}