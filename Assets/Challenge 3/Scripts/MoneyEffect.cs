using UnityEngine;

public class MoneyEffect : MonoBehaviour
{
    public GameObject fireworksParticlePrefab;
    public AudioClip moneySound;

    private AudioSource playerAudio;

    void Start()
    {
        // 🔥 pega o audio do player corretamente
        playerAudio = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            Vector3 pos = other.transform.position;

            GameObject fx = Instantiate(fireworksParticlePrefab, pos, Quaternion.identity);

            ParticleSystem ps = fx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // 🔥 TOCA O SOM
            if (playerAudio != null && moneySound != null)
            {
                playerAudio.PlayOneShot(moneySound, 1.0f);
            }

            Destroy(gameObject);
        }
    }
}