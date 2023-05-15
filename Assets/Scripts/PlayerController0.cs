using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController0 : MonoBehaviour
{
    public GameManager GameManager;
    private float speed = 10.0f;
    private Rigidbody playerRb;


    public AudioSource playerAudio;
    public AudioClip GameOverSound;
    public AudioClip crashSound;
    public AudioClip powerupSound;

    public float rotationAmount = 10f;  // Amount of rotation in degrees
    public float rotationSpeed = 5f;    // Speed of rotation
    public float returnSpeed = 2f;      // Speed of returning to the initial rotation
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive == true)
        {
            MovePlayer();

            // Check for input to initiate rotation
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                isRotating = true;
            }

            // Check for input release to stop rotation and return to initial rotation
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                isRotating = false;
            }

            // Rotate the object while the keys are held down
            if (isRotating)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    RotateObject(Vector3.left);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    RotateObject(Vector3.right);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    RotateObject(Vector3.forward);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    RotateObject(Vector3.back);
                }
            }
            else
            {
                // Gradually return to the initial rotation
                if (Quaternion.Angle(transform.rotation, initialRotation) > 0.01f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * returnSpeed);
                }
            }
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
            playerAudio.PlayOneShot(GameOverSound, 1.0f);
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

    private void RotateObject(Vector3 axis)
    {
        // Calculate the target rotation based on the specified axis
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + axis * rotationAmount);

        // Rotate towards the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

