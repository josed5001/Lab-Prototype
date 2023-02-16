using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController0 : MonoBehaviour
{
    private float speed = 10.0f;
    private float yBound = 17.5f;
    private float yBound2 = 0.5f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        BoundariesPlayerPos();
        
    }

    // Moves the Player Up/Down/Right/Left
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.up * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    // Set boundaries on the player
    void BoundariesPlayerPos()
    {
        if(transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound);
        }
        if(transform.position.y < yBound2)
        {
            transform.position = new Vector3(transform.position.x, yBound2);
        }
    }
}
