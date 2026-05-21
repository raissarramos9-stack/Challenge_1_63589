using UnityEngine;
using System.Collections;

public class Powerup13 : MonoBehaviour
{
    public float powerupTime = 7f;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            // desativa collider
            GetComponent<Collider>().enabled = false;

            // prende no player
            transform.SetParent(other.transform);

            // posição abaixo do player
            transform.localPosition =
                new Vector3(0, -0.5f, 0);

            // começa timer
            StartCoroutine(PowerupCountdown());
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(powerupTime);

        Destroy(gameObject);
    }
}