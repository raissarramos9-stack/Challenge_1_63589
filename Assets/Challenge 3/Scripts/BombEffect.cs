using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explodeSound;

    private AudioSource playerAudio;

    void Start()
    {
        // 🔥 mais seguro (evita erro se não achar)
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerAudio = player.GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

       

        // 🔥 pega o PlayerController
        PlayerController8 player = other.GetComponent<PlayerController8>();

        if (player != null && !player.gameOver)
        {
            player.gameOver = true;
        }

        // 💥 posição correta da explosão
        Vector3 pos = other.transform.position;

        // 💥 cria explosão
        GameObject fx = Instantiate(explosionPrefab, pos, Quaternion.identity);

        // 🔥 garante que toca
        ParticleSystem ps = fx.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        // 🔊 som
        if (playerAudio != null && explodeSound != null)
        {
            playerAudio.PlayOneShot(explodeSound, 1.0f);
        }

        // 💣 destrói bomba
        Destroy(gameObject);
    }
}