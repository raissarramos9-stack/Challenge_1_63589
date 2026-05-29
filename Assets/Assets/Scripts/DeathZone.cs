using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);

            if (Manager != null)
            {
                Manager.GameOver();
            }
        }
    }
}