using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private float speed = 30f;
    private float zDestroy = 110f;
    private Rigidbody obRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        obRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        obRigidBody.AddForce(Vector3.forward * speed);

        if(transform.position.z > zDestroy)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player and Wall"))
        {
            return;
        }
        Destroy(other.gameObject);
    }
    
}
