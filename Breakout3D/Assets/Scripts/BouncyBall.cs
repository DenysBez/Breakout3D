using System;
using UnityEngine;
using TMPro;
public class BouncyBall : MonoBehaviour
{
    private Vector3 initialPosition;
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    private Rigidbody rb;
    
    int score = 0;
    int lives = 5;
    
    public TextMeshProUGUI scoreText;
    public GameObject[] livesImage;

    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    int brickCount;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
    }

    void Update()
    {
        if (transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = initialPosition;
                rb.velocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }

        if (rb.velocity.magnitude < maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);   
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            score += 10;
            scoreText.text = score.ToString("00000");
            brickCount--;
            if (brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 bounceForce = Vector3.up * 15f;
        rb.AddForce(bounceForce, ForceMode.Impulse);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
