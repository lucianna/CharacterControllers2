using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    //Player's movement params
    public Vector3 direction;
    public float speed;

    public Rigidbody rb; // The player's rigibody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // All physics calculations happen in FixedUpdate
    void FixedUpdate()
    {
        //transform.Translate(direction * speed * Time.deltaTime);

        //make world direction into local direction
        Vector3 localDirection = transform.TransformDirection(direction);
        //move using physics
        rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
        
    }
    //OnPlayer Move event handler
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y components corresponding to the player's WASD and arrow inputs
        // both components are in the range[-1,1]
        Vector2 inputVector = value.Get<Vector2>();
       
        //move in the XZ-plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;

        //just in case
        direction.y = 0f;
    }
}
