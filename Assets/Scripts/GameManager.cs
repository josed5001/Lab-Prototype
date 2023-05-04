using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabDiff;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    private float timeDelay = 15f;
    private float deleteDelay = 14.5f;
    private float score;

    public bool isGameActive = false;
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(prefabSpawn());
        InvokeRepeating("destroyFun", deleteDelay, deleteDelay);
        isGameActive = true;
        scoreText.gameObject.SetActive(true);
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


    // Destroy Objects with said Tag
    void destroyObjectWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }
    void destroyFun()
    {
        // Funtion only used for the InvokeRepeating In Start
        destroyObjectWithTag("Level");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        
    }

    // Spawn Level Prefabs
    IEnumerator prefabSpawn()
    {
        int currentIndex = 0;

        while (currentIndex < prefabDiff.Length)
        {
            Instantiate(prefabDiff[currentIndex], transform.position, prefabDiff[currentIndex].gameObject.transform.rotation);
            currentIndex++;

            if (currentIndex >= prefabDiff.Length) // check if currentIndex has reached the end of the array
            {
                currentIndex = 0; // reset currentIndex to 0 to start over from the beginning of the array
            }
            yield return new WaitForSeconds(timeDelay);
        }
    }

    // Turns off the GameManager and removes any Level Prefabs if there's any
    public void TurnOff()
    {
        destroyObjectWithTag("Level");
        gameObject.SetActive(false);
    }
}
