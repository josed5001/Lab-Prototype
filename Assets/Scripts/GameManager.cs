using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabDiff;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float timeDelay = 10f;
    private float deleteDelay = 9.5f;
    private float score;

    public bool isGameActive = false;
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(prefabSpawn());
        InvokeRepeating("destroyFun", deleteDelay, deleteDelay);
        isGameActive = true;
        score = 0;
        pointIncreasedPerSecond = 10f;
         
            
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive == true)
        {
            score += pointIncreasedPerSecond * Time.deltaTime;
            int roundedScore = Mathf.RoundToInt(score);
            scoreText.text = "Score: " + roundedScore.ToString();
        }
        
    }


    void destroyLevelWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }
    void destroyFun()
    {
        destroyLevelWithTag("Level");
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        
    }
    IEnumerator prefabSpawn()
    {
        int currentIndex = 0;

        while (currentIndex < prefabDiff.Length)
        {
            Instantiate(prefabDiff[currentIndex], transform.position, prefabDiff[currentIndex].gameObject.transform.rotation);
            currentIndex++;

            yield return new WaitForSeconds(timeDelay);
        }
    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
