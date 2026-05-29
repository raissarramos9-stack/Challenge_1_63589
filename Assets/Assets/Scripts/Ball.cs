using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public float BallSpeed = 2.5f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.constraints =
            RigidbodyConstraints.FreezePositionZ |
            RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector3 velocity = m_Rigidbody.linearVelocity;

        velocity.z = 0f;

        if (velocity.magnitude > 0.01f)
        {
            velocity = velocity.normalized * BallSpeed;

            // Evita que a bola fique quase horizontal
            if (Mathf.Abs(velocity.y) < 0.3f)
            {
                velocity.y = velocity.y >= 0 ? 0.3f : -0.3f;
                velocity = velocity.normalized * BallSpeed;
            }

            // Evita que fique quase vertical
            if (Mathf.Abs(velocity.x) < 0.3f)
            {
                velocity.x = velocity.x >= 0 ? 0.3f : -0.3f;
                velocity = velocity.normalized * BallSpeed;
            }

            m_Rigidbody.linearVelocity = velocity;
        }
    }
}