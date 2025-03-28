using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float maxX = 6.2f;
    float movementHorizontal;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if ((movementHorizontal > 0 && transform.position.x < maxX)
            || (movementHorizontal < 0 && transform.position.x > -maxX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}
