using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = false;
    private float score;
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
         score = 0;
        
         pointIncreasedPerSecond = 10f;
         
            
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive == true)
        {score += pointIncreasedPerSecond * Time.deltaTime;
        int roundedScore = Mathf.RoundToInt(score);
        scoreText.text = "Score: " + roundedScore.ToString();
        }
        
    }
    
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        
    }
   
    
   
    


    
    
}
