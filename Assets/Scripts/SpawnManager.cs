using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] powerUps;
    public Transform[] powerUpPos;

    private float zObstacleSpawn = 100.0f;
    private float xSpawn = -1.0f;
    private float ySpawn = 9.0f;

    private float obstacleSpawnTime = 3.1f;
    private float powerUpSpawnTime = 5.3f;
    private float startDelay = 1.0f;

    public bool ObSpawnChange = false;

    private float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("SpawnObstacle", startDelay, obstacleSpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the time elapsed
        timeElapsed += Time.deltaTime;

        // Check if # seconds has passed
        if (timeElapsed >= 30f)
        {
            obstacleSpawnTime = 0.5f; //error: The obstacle spawn time does not change.
            ObSpawnChange = true;
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
        int PowerUpIndex = Random.Range(0, powerUps.Length);
        int PowerUpPosIndex = Random.Range(0, powerUpPos.Length);

        Instantiate(powerUps[PowerUpIndex], powerUpPos[PowerUpIndex].position, powerUps[PowerUpIndex].gameObject.transform.rotation);
    }
}
