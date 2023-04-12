using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject powerUp;
    public Vector3[] powerUpPos;

    private float zObstacleSpawn = 12.0f;
    private float xSpawn = -1.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 9.0f;

    private float obstacleSpawnTime = 2.1f;
    private float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, obstacleSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnObstacle()
    {
        Vector3 SpawnPos = new Vector3(xSpawn, ySpawn, zObstacleSpawn);
        int RandomIndex = Random.Range(0, obstacles.Length);
        
        Instantiate(obstacles[RandomIndex], SpawnPos, obstacles[RandomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        
    }
}
