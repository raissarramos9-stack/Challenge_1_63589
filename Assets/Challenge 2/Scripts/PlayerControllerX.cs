using UnityEngine; // Importa a biblioteca principal da Unity para usar classes como MonoBehaviour, GameObject, etc.

public class PlayerController3 : MonoBehaviour // Define a classe do script que controla o jogador
{
    public GameObject DogPrefab; // Referência ao prefab do cachorro que será criado (instanciado) no jogo
    
    // Mudei para 0.15. Assim podes disparar cerca de 6 a 7 cães por segundo!

    private float intervaloDisparo = 0.90f; // Define o tempo mínimo (em segundos) entre cada disparo de cachorro
    private float proximoDisparo = 0.5f;    // Guarda o momento em que o jogador poderá disparar novamente

    void Update() // Função chamada automaticamente pela Unity em todos os frames do jogo
    {
        // Verifica se o jogador pressionou a tecla Espaço e se já passou o tempo de espera entre disparos
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > proximoDisparo)
        {
            // Atualiza o tempo do próximo disparo
            proximoDisparo = Time.time + intervaloDisparo;

            // Cria (instancia) um cachorro na posição atual do jogador
            Instantiate(DogPrefab, transform.position, DogPrefab.transform.rotation);
        }
    }
}