using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController0 : MonoBehaviour
{
    public GameManager GameManager;
    private float speed = 10.0f;
    private Rigidbody playerRb;


    public AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip powerupSound;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive == true)
        {
            MovePlayer();
        }
            
        
    }

    // Moves the Player Up/Down/Right/Left
    void MovePlayer()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        playerRb.AddForce(Vector3.up * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

    }
  

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Player collided with Obstacle");
            GameManager.isGameActive = false;
            GameManager.GameOver();
            GameManager.TurnOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(powerupSound, 1.0f);
        }
    }
}
