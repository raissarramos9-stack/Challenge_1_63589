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
            // MOVE PARA A DIREITA
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }

        // DESTROI QUANDO SAIR DA TELA (lado direito)
        if (transform.position.x > 200 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}