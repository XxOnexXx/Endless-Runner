using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner Instance;
    [SerializeField] GameObject[] obsctacles;

    float timer = 0f;
    [SerializeField] float spawnTimer = 2f;
    [SerializeField] float diffucultyTimer = 10f;
    float maxDifficultyTimer = 1.4f;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpanwObstacle();
    }


    void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= diffucultyTimer && spawnTimer >= maxDifficultyTimer)
        {
            spawnTimer -= 0.1f;
        }
        
        if (timer >= spawnTimer)
        {
            SpanwObstacle();
            timer = 0f;
        }

    }

    private void SpanwObstacle()
    {
        float randPos = Random.Range(1.2f, -1.2f); ;
        int randObstacle = Random.Range(0, obsctacles.Length);
        GameObject obstaclePattern = Instantiate(obsctacles[randObstacle], new Vector3(transform.position.x, transform.position.y, transform.position.z + randPos), Quaternion.identity);
        Destroy(obstaclePattern, 6f);
    }
}
