using UnityEngine;

public class MoveForward30 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float xDestroy = 30f;

    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        // movimento baseado na direção do objeto
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void CheckBounds()
    {
        if (transform.position.x > xDestroy)
        {
            gameObject.SetActive(false); // melhor que Destroy
        }
    }
}