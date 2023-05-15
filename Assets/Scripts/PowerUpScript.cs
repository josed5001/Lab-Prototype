using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{   
    public PlayerController0 playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.Powerup1 = true)
        {
            powerUpTags();
        }
    }

    void powerUpTags()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            if(taggedObject.CompareTag("Powerup"))
            {

            }
            else if(taggedObject.CompareTag("PowerUp2"))
            {

            }
            else if(taggedObject.CompareTag("PowerUp3"))
            {

            }
            else if(taggedObject.CompareTag("PowerUp4"))
            {

            }
        }
    }
}
