using UnityEngine;

public class DetectCollisions5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // COLISÃO COM ANIMAL
        if (other.CompareTag("Animal"))
        {
            // DESATIVA O ANIMAL (POOLING)
            other.gameObject.SetActive(false);

            // DESATIVA O PROJÉTIL
            gameObject.SetActive(false);
        }
    }
}