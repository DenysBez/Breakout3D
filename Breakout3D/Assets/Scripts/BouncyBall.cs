using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class BouncyBall : MonoBehaviour
{
    [SerializeField] private AudioSource collisionAudio;
    [SerializeField] private AudioSource destroyedBrickAudio;

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

            if (destroyedBrickAudio != null)
            {
                destroyedBrickAudio.Play();
            }
        }
        
        if (collisionAudio != null)
        {
            collisionAudio.Play();
        }
        
        Rigidbody rb = GetComponent<Rigidbody>();
        float randomX = Random.Range(-3f, 3f); // Slight random movement to the left or right
        Vector3 bounceForce = new Vector3(randomX, 12f, 0f); 
        rb.AddForce(bounceForce, ForceMode.Impulse);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
