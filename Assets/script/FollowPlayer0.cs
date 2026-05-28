using UnityEngine;

public class FollowPlayer0 : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Distância da câmera")]
    [SerializeField] private Vector3 offset =
        new Vector3(0, 2, 1);

    void LateUpdate()
    {
        // Evita erro caso player esteja vazio
        if (player == null)
            return;

        // Segue o player
        transform.position =
            player.transform.position +
            player.transform.rotation * offset;

        // Olha para o player
        transform.LookAt(
            player.transform.position +
            Vector3.up * 2
        );
    }
}