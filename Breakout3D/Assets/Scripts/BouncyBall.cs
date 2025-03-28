using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    private Vector3 initialPosition;
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            transform.position = initialPosition;
            rb.velocity = Vector3.zero;
        }

        if (rb.velocity.magnitude < maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);   
        }
    }
}
