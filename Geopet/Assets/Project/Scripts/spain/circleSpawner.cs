using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject circlePrefab;
    public float spawnInterval = 2.25f;    
    public Vector2 spawnAreaMin = new Vector2(-8f, -4f);
    public Vector2 spawnAreaMax = new Vector2(8f, 4f);

    [Header("Difficulty")]
    public bool increaseDifficulty = true;
    public float minSpawnInterval = 0.3f;
    public float difficultyIncreaseRate = 0.05f;  
    private float nextSpawnTime;
    private float gameStartTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        gameStartTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCircle();
            nextSpawnTime = Time.time + spawnInterval;

            
            if (increaseDifficulty)
            {
                float elapsedTime = Time.time - gameStartTime;
                spawnInterval = Mathf.Max(
                    minSpawnInterval,
                    spawnInterval - (difficultyIncreaseRate * Time.deltaTime)
                );
            }
        }
    }

    void SpawnCircle()
    {
        if (circlePrefab == null)
        {
            Debug.LogError("Circle Prefab no asignado!");
            return;
        }

        
        Vector2 randomPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject circle = Instantiate(circlePrefab, randomPos, Quaternion.identity);
        circle.name = "HitCircle_" + Time.time;
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = new Vector3(
            (spawnAreaMin.x + spawnAreaMax.x) / 2f,
            (spawnAreaMin.y + spawnAreaMax.y) / 2f,
            0f
        );
        Vector3 size = new Vector3(
            spawnAreaMax.x - spawnAreaMin.x,
            spawnAreaMax.y - spawnAreaMin.y,
            0f
        );
        Gizmos.DrawWireCube(center, size);
    }
}
