using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] powerUps;
    public Transform[] powerUpPos;
    private GameDifficulty gameDifficulty;


    private float zObstacleSpawn = 100.0f;
    private float xSpawn = -1.0f;
    private float ySpawn = 9.0f;

    private Vector3 bottomLeftCorner;
    private Vector3 topRightCorner;

    
    private float powerUpSpawnTime = 5f;
    public float startDelay = 1.0f;
    public bool ObSpawnChange = false;
    public bool isSpawningWalls = false;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeftCorner = new Vector3(-8.5f, 1f, 100f);
        topRightCorner = new Vector3(6.5f, 16f, 100f);

        gameDifficulty = GameObject.Find("GameDifficulty").GetComponent<GameDifficulty>();
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
        StartCoroutine(SpawnObstaclesRoutine());
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
   
    
    public IEnumerator SpawnObstaclesRoutine()
    {
	    
          
        // Wait for our start delay to make sure we mimic the previous InvokeRepeating behaviour.
        yield return new WaitForSeconds(startDelay);
        // This variable is class varible so that you can have this coroutine end gracefully from outside of the coroutine itself.
        isSpawningWalls = true;
        // Start with the default spawn time.
        float spawnTime = gameDifficulty.obstacleSpawnTime;
	    float minimumSpawnTime = 0.1f;
	    float timeElapsed = 0f;
	    while (isSpawningWalls)
	    {
            // Check if our elapsedTime has exceeded the amount of time we want between speed increases.
	        if (timeElapsed > 11f)
	        {
                // If it has, then decrease the spawnTime by our desired amount.
                // Use a Mathf.Max() function so that we never go below our minimum value (which should be >0f)
                spawnTime = Mathf.Max(minimumSpawnTime, spawnTime - 0.5f);
                // Then reset our time elapsed variable to 0 so that we start counting fresh next spawn.
                timeElapsed = 0f;
	        }
            // Spawn the obstacle.
            SpawnObstacle();
            // Yield for spawnTime seconds. This is an "asynchronous" wait operation, so everything not in this coroutine will continue.
            yield return new WaitForSeconds(spawnTime);
            // Update our time elapsed by the amount of time we just waited for.
            timeElapsed += spawnTime;
	    }
    }
    
            
	    
        
    
    


    void SpawnObstacle()
    {
        Vector3 SpawnPos = new Vector3(xSpawn, ySpawn, zObstacleSpawn);
        int RandomIndex = Random.Range(0, obstacles.Length);
        
        Instantiate(obstacles[RandomIndex], SpawnPos, obstacles[RandomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        float x = Random.Range(bottomLeftCorner.x, topRightCorner.x);
        float y = Random.Range(bottomLeftCorner.y, topRightCorner.y);
        Vector3 spawnPosition = new Vector3(x, y, 100);
        int PowerUpIndex = Random.Range(0, powerUps.Length);

        Instantiate(powerUps[PowerUpIndex], spawnPosition, Quaternion.identity);
    }

   
}
