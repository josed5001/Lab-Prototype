using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public SpawnManager spawnManager;
    public float spawnTime;
	public float minimumSpawnTime = 0.1f;
	public float timeElapsed = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstaclesRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator SpawnObstaclesRoutine()
    { 
        spawnTime = spawnManager.obstacleSpawnTime;
        // Wait for our start delay to make sure we mimic the previous InvokeRepeating behaviour.
        yield return new WaitForSeconds(spawnManager.startDelay);
        // This variable is class varible so that you can have this coroutine end gracefully from outside of the coroutine itself.
        spawnManager.isSpawningWalls = true;
        // Start with the default spawn time.
        
	    while (spawnManager.isSpawningWalls)
	    {
            // Check if our elapsedTime has exceeded the amount of time we want between speed increases.
	        if (timeElapsed > 30f)
	        {
                // If it has, then decrease the spawnTime by our desired amount.
                // Use a Mathf.Max() function so that we never go below our minimum value (which should be >0f)
                spawnTime = Mathf.Max(minimumSpawnTime, spawnTime - 0.5f);
                // Then reset our time elapsed variable to 0 so that we start counting fresh next spawn.
                timeElapsed = 0f;
	        }
            spawnManager.SpawnRoutine();
        }    
    }
}
