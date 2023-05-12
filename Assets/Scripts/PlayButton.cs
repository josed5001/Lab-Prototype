using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(PlayStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayStart()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame();
    }
}
