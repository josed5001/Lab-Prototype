using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] powerUps;
    public Transform[] powerUpPos;
    public GameDifficulty gameDifficulty;

    private float zObstacleSpawn = 100.0f;
    private float xSpawn = -1.0f;
    private float ySpawn = 9.0f;

    private float obstacleSpawnTime = 3f;
    private float powerUpSpawnTime = 5f;
    private float startDelay = 1.0f;
    public bool ObSpawnChange = false;
    private bool isSpawningWalls = false;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
        StartCoroutine(GameDifficulty.SpawnObstaclesRoutine());
    
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the time elapsed
        timeElapsed = Time.time;

        // Check if # seconds has passed
        if (timeElapsed > 30f)
        {
            ObSpawnChange = true;
        }

        
    }
    public IEnumerator SpawnRoutine()
    {
        // Spawn the obstacle.
        SpawnObstacle();
        // Yield for spawnTime seconds. This is an "asynchronous" wait operation, so everything not in this coroutine will continue.
        yield return new WaitForSeconds(spawnTime);
        // Update our time elapsed by the amount of time we just waited for.
        timeElapsed += spawnTime;
    }
    
            
	    
        
    
    


    void SpawnObstacle()
    {
        Vector3 SpawnPos = new Vector3(xSpawn, ySpawn, zObstacleSpawn);
        int RandomIndex = Random.Range(0, obstacles.Length);
        
        Instantiate(obstacles[RandomIndex], SpawnPos, obstacles[RandomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        int PowerUpIndex = Random.Range(0, powerUps.Length);
        int PowerUpPosIndex = Random.Range(0, powerUpPos.Length);

        Instantiate(powerUps[PowerUpIndex], powerUpPos[PowerUpIndex].position, powerUps[PowerUpIndex].gameObject.transform.rotation);
    }

   
}
