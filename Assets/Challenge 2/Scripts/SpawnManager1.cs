using UnityEngine; // Importa a biblioteca principal da Unity para usar funções e classes do motor

public class SpawnManager1 : MonoBehaviour // Define a classe responsável por gerar (spawnar) as bolas no jogo
{
    public GameObject[] bolasPrefabs; // Array que guarda os prefabs das bolas que podem aparecer no jogo

    private float limiteXEsquerda = -22; // Limite da área onde as bolas podem aparecer no lado esquerdo
    private float limiteXDireita = 7;    // Limite da área onde as bolas podem aparecer no lado direito
    private float spawnPosY = 30f;       // Altura (eixo Y) onde as bolas vão aparecer, ou seja, no topo do cenário
    private float spawnPosZ = 30f;       // Posição no eixo Z do cenário (no seu código não está sendo usada)

    void Start() // Função executada automaticamente quando o jogo começa
    {
        // Chama a função CriarBolaAleatoria após 1 segundo
        Invoke("CriarBolaAleatoria", 0.90f);
    }

    void CriarBolaAleatoria() // Função responsável por criar uma nova bola
    {
        // Escolhe uma bola aleatória do array (por exemplo Ball1, Ball2 ou Ball3)
        int index = Random.Range(0, bolasPrefabs.Length);

        // Define uma posição aleatória no eixo X, mantendo a altura definida (spawnPosY)
        Vector3 spawnPos = new Vector3(
            Random.Range(limiteXEsquerda, limiteXDireita), // posição aleatória entre os limites
            spawnPosY,                                     // altura onde a bola nasce
            0                                              // posição no eixo Z
        );
        
        // Cria (instancia) a bola escolhida na posição definida
        Instantiate(bolasPrefabs[index], spawnPos, bolasPrefabs[index].transform.rotation);

        // Define o tempo para criar a próxima bola (entre 1 e 2 segundos)
        float tempoAleatorio = Random.Range(1.0f, 2.0f);

        // Agenda a execução da função novamente após o tempo aleatório
        Invoke("CriarBolaAleatoria", tempoAleatorio);
    }
}