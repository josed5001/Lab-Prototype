using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    
    public float obstacleSpawnTime = 3f;
    public float subtractValue = 1f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(timer > 10f)
        {
            obstacleSpawnTime -= subtractValue;

            timer = 0f;
        }
    }
    
   
}
