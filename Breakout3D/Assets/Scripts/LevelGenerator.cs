using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGenerator : MonoBehaviour
{
    public Vector3Int size;
    public Vector3 offset;
    public GameObject brickPrefab;


    private void Awake()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3(((size.x-1)*.5f-i) * offset.x, j + offset.y, 0);
            }
        }
    }

    void Start()
    {
        
    }
    

    void Update()
    {
        
    }
}
