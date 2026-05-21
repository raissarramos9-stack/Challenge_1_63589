using UnityEngine;

public class MoveSide30 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}