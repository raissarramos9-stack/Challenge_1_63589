using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -10);

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.transform.position + offset;
    }
}
