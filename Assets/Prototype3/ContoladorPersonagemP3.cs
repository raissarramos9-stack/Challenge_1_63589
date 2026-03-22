using UnityEngine;

public class ControladorPersonagemP3 : MonoBehaviour
{
    // --- Componentes ---
    private Rigidbody rbJogador;
    private Animator playerAnim;
    private AudioSource somJogador;

    // --- Variáveis de Configuração ---
    [Header("Física e Movimento")]
    public float forcaSalto = 10.0f;
    public float modificadorGravidade = 2.0f;
    public bool estaNoChao = true;
    public bool gameOver = false;

    [Header("Efeitos Visuais")]
    public ParticleSystem particulaExplosao;
    public ParticleSystem particulaPoeira;

    [Header("Efeitos Sonoros")]
    public AudioClip somSalto;
    public AudioClip somBatida;

    void Start()
    {
        rbJogador = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        somJogador = GetComponent<AudioSource>();

        Physics.gravity = new Vector3(0, -9.81f, 0) * modificadorGravidade;

        if (particulaPoeira != null)
        {
            particulaPoeira.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao && !gameOver)
        {
            rbJogador.AddForce(Vector3.up * forcaSalto, ForceMode.Impulse);
            estaNoChao = false;

            playerAnim.SetTrigger("Jump_trig");
            somJogador.PlayOneShot(somSalto, 1.0f);

            if (particulaPoeira != null)
            {
                particulaPoeira.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            estaNoChao = true;

            if (particulaPoeira != null)
            {
                particulaPoeira.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over: Colisão detectada.");

            playerAnim.SetTrigger("Death");

            // 💥 EXPLOSÃO
            if (particulaExplosao != null)
            {
                particulaExplosao.transform.position = transform.position;
                particulaExplosao.Play();
            }

            // Poeira para
            if (particulaPoeira != null)
            {
                particulaPoeira.Stop();
            }

            somJogador.PlayOneShot(somBatida, 1.0f);
        }
    }
}