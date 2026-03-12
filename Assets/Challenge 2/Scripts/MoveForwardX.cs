using UnityEngine; // Importa a biblioteca principal da Unity para usar classes e funções do motor

public class MoverForwardX : MonoBehaviour // Define a classe do script responsável por mover o objeto
{
    public float velocidade = 20.0f; // Define a velocidade com que o objeto se move

    void Update() // Função chamada automaticamente pela Unity a cada frame do jogo
    {
        if (!enabled) return; // Se o script estiver desativado, o código para aqui e não executa o resto

        // Move o objeto para frente continuamente usando a velocidade definida
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }
}