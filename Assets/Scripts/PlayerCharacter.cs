using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float moveInput;

    // Use this for initialization
    void Start () {
        Debug.Log("This is start!");
	}

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigidBody.velocity = new Vector2(moveInput * movementSpeed, myRigidBody.velocity.y);
    }

    private void Jump()
    {
        //TODO: Make the character jump

    }

    private void GetMovementInput()
    {
        moveInput = Input.GetAxis("Horizontal");
    }
}
